using AutoMapper;
using Dominio;
using Dominio.Interfaces;
using Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

 public class TypeIncidenceController : BaseApiController
{

     private readonly IUnitOfWork unitofwork;
     private readonly IMapper mapper;

    public TypeIncidenceController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TypeIncidence>>> Get()
    {
        var Con = await  unitofwork.TypeIncidences.GetAllAsync();
        return Ok(Con);
    }

     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  unitofwork.TypeIncidences.GetByIdAsync(id);
        return Ok(byidC);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TypeIncidence>> Post(TypeIncidence typeIncidence){
        this.unitofwork.TypeIncidences.Add(typeIncidence);
        await unitofwork.SaveAsync();
        if(typeIncidence == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= typeIncidence.Id}, typeIncidence);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TypeIncidence>> Put(int id, [FromBody]TypeIncidence typeIncidence){
        if(typeIncidence == null)
            return NotFound();
        unitofwork.TypeIncidences.Update(typeIncidence);
        await unitofwork.SaveAsync();
        return typeIncidence;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await unitofwork.TypeIncidences.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        unitofwork.TypeIncidences.Remove(D);
        await unitofwork.SaveAsync();
        return NoContent();
    }


   
}
