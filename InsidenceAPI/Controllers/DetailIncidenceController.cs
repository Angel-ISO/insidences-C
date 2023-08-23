using AutoMapper;
using Dominio;
using Dominio.Interfaces;
using Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

 public class DetailIncidenceController : BaseApiController
{

     private readonly IUnitOfWork unitofwork;
     private readonly IMapper mapper;

    public DetailIncidenceController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DetailIncidence>>> Get()
    {
        var Con = await  unitofwork.DetailIncidences.GetAllAsync();
        return Ok(Con);
    }

     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  unitofwork.ContactTypes.GetByIdAsync(id);
        return Ok(byidC);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetailIncidence>> Post(DetailIncidence detailIncidence){
        this.unitofwork.DetailIncidences.Add(detailIncidence);
        await unitofwork.SaveAsync();
        if(detailIncidence == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= detailIncidence.Id}, detailIncidence);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetailIncidence>> Put(int id, [FromBody]DetailIncidence detailIncidence){
        if(detailIncidence == null)
            return NotFound();
        unitofwork.DetailIncidences.Update(detailIncidence);
        await unitofwork.SaveAsync();
        return detailIncidence;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await unitofwork.DetailIncidences.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        unitofwork.DetailIncidences.Remove(D);
        await unitofwork.SaveAsync();
        return NoContent();
    }


   
}