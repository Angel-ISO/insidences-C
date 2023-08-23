using AutoMapper;
using Dominio;
using Dominio.Interfaces;
using Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

 public class ContactTypeController : BaseApiController
{

     private readonly IUnitOfWork unitofwork;
     private readonly IMapper mapper;

    public ContactTypeController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ContactType>>> Get()
    {
        var Con = await  unitofwork.ContactTypes.GetAllAsync();
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
    public async Task<ActionResult<ContactType>> Post(ContactType contactType){
        this.unitofwork.ContactTypes.Add(contactType);
        await unitofwork.SaveAsync();
        if(contactType == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= contactType.Id}, contactType);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContactType>> Put(int id, [FromBody]ContactType contactType){
        if(contactType == null)
            return NotFound();
        unitofwork.ContactTypes.Update(contactType);
        await unitofwork.SaveAsync();
        return contactType;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await unitofwork.ContactTypes.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        unitofwork.ContactTypes.Remove(D);
        await unitofwork.SaveAsync();
        return NoContent();
    }


   
}