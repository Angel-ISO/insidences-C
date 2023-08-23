using AutoMapper;
using Dominio;
using Dominio.Interfaces;
using Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

 public class AddressController : BaseApiController
{

     private readonly IUnitOfWork unitofwork;
     private readonly IMapper mapper;

    public AddressController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Address>>> Get()
    {
        var Con = await  unitofwork.Addresses.GetAllAsync();
        return Ok(Con);
    }

     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  unitofwork.Addresses.GetByIdAsync(id);
        return Ok(byidC);
    }

 [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Address>> Post(Address address){
        this.unitofwork.Addresses.Add(address);
        await unitofwork.SaveAsync();
        if(address == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= address.Id}, address);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Address>> Put(int id, [FromBody]Address address){
        if(address == null)
            return NotFound();
        unitofwork.Addresses.Update(address);
        await unitofwork.SaveAsync();
        return address;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await unitofwork.Addresses.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        unitofwork.Addresses.Remove(D);
        await unitofwork.SaveAsync();
        return NoContent();
    }


   
}