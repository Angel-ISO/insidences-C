using AutoMapper;
using Dominio;
using Dominio.Interfaces;
using Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

 public class RolController : BaseApiController
{

     private readonly IUnitOfWork unitofwork;
     private readonly IMapper mapper;

    public RolController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Rol>>> Get()
    {
        var Con = await  unitofwork.Rols.GetAllAsync();
        return Ok(Con);
    }

     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  unitofwork.Rols.GetByIdAsync(id);
        return Ok(byidC);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Rol>> Post(Rol rol){
        this.unitofwork.Rols.Add(rol);
        await unitofwork.SaveAsync();
        if(rol == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= rol.Id}, rol);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Rol>> Put(int id, [FromBody]Rol rol){
        if(rol == null)
            return NotFound();
        unitofwork.Rols.Update(rol);
        await unitofwork.SaveAsync();
        return rol;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await unitofwork.Rols.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        unitofwork.Rols.Remove(D);
        await unitofwork.SaveAsync();
        return NoContent();
    }


   
}
