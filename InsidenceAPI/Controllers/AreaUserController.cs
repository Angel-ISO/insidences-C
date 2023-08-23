using AutoMapper;
using Dominio;
using Dominio.Interfaces;
using Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

 public class AreaUserController : BaseApiController
{

     private readonly IUnitOfWork unitofwork;
     private readonly IMapper mapper;

    public AreaUserController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AreaUser>>> Get()
    {
        var Con = await  unitofwork.AreaUsers.GetAllAsync();
        return Ok(Con);
    }

     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  unitofwork.AreaUsers.GetByIdAsync(id);
        return Ok(byidC);
    }

 [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AreaUser>> Post(AreaUser areaUser){
        this.unitofwork.AreaUsers.Add(areaUser);
        await unitofwork.SaveAsync();
        if(areaUser == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= areaUser.Id}, areaUser);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AreaUser>> Put(int id, [FromBody]AreaUser areaUser){
        if(areaUser == null)
            return NotFound();
        unitofwork.AreaUsers.Update(areaUser);
        await unitofwork.SaveAsync();
        return areaUser;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await unitofwork.AreaUsers.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        unitofwork.AreaUsers.Remove(D);
        await unitofwork.SaveAsync();
        return NoContent();
    }


   
}