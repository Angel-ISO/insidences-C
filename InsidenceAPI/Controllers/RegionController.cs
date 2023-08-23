using AutoMapper;
using Dominio;
using Dominio.Interfaces;
using Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

 public class RegionController : BaseApiController
{

     private readonly IUnitOfWork unitofwork;
     private readonly IMapper mapper;

    public RegionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Region>>> Get()
    {
        var Con = await  unitofwork.Regions.GetAllAsync();
        return Ok(Con);
    }
     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  unitofwork.Regions.GetByIdAsync(id);
        return Ok(byidC);
    }
 [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Region>> Post(Region region){
        this.unitofwork.Regions.Add(region);
        await unitofwork.SaveAsync();
        if(region == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= region.Id}, region);
    }

    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Region>> Put(int id, [FromBody]Region region){
        if(region == null)
            return NotFound();
        unitofwork.Regions.Update(region);
        await unitofwork.SaveAsync();
        return region;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await unitofwork.Regions.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        unitofwork.Regions.Remove(D);
        await unitofwork.SaveAsync();
        return NoContent();
    }



}