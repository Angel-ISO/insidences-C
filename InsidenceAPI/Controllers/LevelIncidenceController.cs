using AutoMapper;
using Dominio;
using Dominio.Interfaces;
using Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

 public class LevelIncidenceController : BaseApiController
{

     private readonly IUnitOfWork unitofwork;
     private readonly IMapper mapper;

    public LevelIncidenceController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<LevelIncidence>>> Get()
    {
        var Con = await  unitofwork.LevelIncidences.GetAllAsync();
        return Ok(Con);
    }

     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  unitofwork.LevelIncidences.GetByIdAsync(id);
        return Ok(byidC);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LevelIncidence>> Post(LevelIncidence levelIncidence){
        this.unitofwork.LevelIncidences.Add(levelIncidence);
        await unitofwork.SaveAsync();
        if(levelIncidence == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= levelIncidence.Id}, levelIncidence);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LevelIncidence>> Put(int id, [FromBody]LevelIncidence levelIncidence){
        if(levelIncidence == null)
            return NotFound();
        unitofwork.LevelIncidences.Update(levelIncidence);
        await unitofwork.SaveAsync();
        return levelIncidence;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await unitofwork.LevelIncidences.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        unitofwork.LevelIncidences.Remove(D);
        await unitofwork.SaveAsync();
        return NoContent();
    }


   
}