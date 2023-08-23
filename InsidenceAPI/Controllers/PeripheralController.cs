using AutoMapper;
using Dominio;
using Dominio.Interfaces;
using Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

 public class PeripheralController : BaseApiController
{

     private readonly IUnitOfWork unitofwork;
     private readonly IMapper mapper;

    public PeripheralController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Peripheral>>> Get()
    {
        var Con = await  unitofwork.Peripherals.GetAllAsync();
        return Ok(Con);
    }

     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  unitofwork.Peripherals.GetByIdAsync(id);
        return Ok(byidC);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Peripheral>> Post(Peripheral peripheral){
        this.unitofwork.Peripherals.Add(peripheral);
        await unitofwork.SaveAsync();
        if(peripheral == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= peripheral.Id}, peripheral);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Peripheral>> Put(int id, [FromBody]Peripheral peripheral){
        if(peripheral == null)
            return NotFound();
        unitofwork.Peripherals.Update(peripheral);
        await unitofwork.SaveAsync();
        return peripheral;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await unitofwork.Peripherals.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        unitofwork.Peripherals.Remove(D);
        await unitofwork.SaveAsync();
        return NoContent();
    }


   
}