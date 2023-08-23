using AutoMapper;
using Dominio;
using Dominio.Interfaces;
using Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

 public class IncidenceController : BaseApiController
{

     private readonly IUnitOfWork unitofwork;
     private readonly IMapper mapper;

    public IncidenceController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Incidence>>> Get()
    {
        var Con = await  unitofwork.Incidences.GetAllAsync();
        return Ok(Con);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  unitofwork.Incidences.GetByIdAsync(id);
        return Ok(byidC);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Incidence>> Post(Incidence incidence){
        this.unitofwork.Incidences.Add(incidence);
        await unitofwork.SaveAsync();
        if(incidence == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= incidence.Id}, incidence);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Incidence>> Put(int id, [FromBody]Incidence incidence){
        if(incidence == null)
            return NotFound();
        unitofwork.Incidences.Update(incidence);
        await unitofwork.SaveAsync();
        return incidence;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await unitofwork.Incidences.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        unitofwork.Incidences.Remove(D);
        await unitofwork.SaveAsync();
        return NoContent();
    }


   
}