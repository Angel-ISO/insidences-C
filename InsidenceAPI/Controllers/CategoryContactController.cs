using AutoMapper;
using Dominio;
using Dominio.Interfaces;
using Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

 public class CategoryContactController : BaseApiController
{

     private readonly IUnitOfWork unitofwork;
     private readonly IMapper mapper;

    public CategoryContactController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CategoryContact>>> Get()
    {
        var Con = await  unitofwork.CategoryContacts.GetAllAsync();
        return Ok(Con);
    }

     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  unitofwork.CategoryContacts.GetByIdAsync(id);
        return Ok(byidC);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoryContact>> Post(CategoryContact categoryContact ){
        this.unitofwork.CategoryContacts.Add(categoryContact);
        await unitofwork.SaveAsync();
        if(categoryContact == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= categoryContact.Id}, categoryContact);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoryContact>> Put(int id, [FromBody]CategoryContact categoryContact){
        if(categoryContact == null)
            return NotFound();
        unitofwork.CategoryContacts.Update(categoryContact);
        await unitofwork.SaveAsync();
        return categoryContact;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await unitofwork.CategoryContacts.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        unitofwork.CategoryContacts.Remove(D);
        await unitofwork.SaveAsync();
        return NoContent();
    }

   
}