using AutoMapper;
using Dominio;
using Dominio.Interfaces;
using Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

 public class ContactController : BaseApiController
{

     private readonly IUnitOfWork unitofwork;
     private readonly IMapper mapper;

    public ContactController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Contact>>> Get()
    {
        var Con = await  unitofwork.Contacts.GetAllAsync();
        return Ok(Con);
    }

     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  unitofwork.Contacts.GetByIdAsync(id);
        return Ok(byidC);
    }

 [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Contact>> Post(Contact contact){
        this.unitofwork.Contacts.Add(contact);
        await unitofwork.SaveAsync();
        if(contact == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= contact.Id}, contact);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Contact>> Put(int id, [FromBody]Contact contact){
        if(contact == null)
            return NotFound();
        unitofwork.Contacts.Update(contact);
        await unitofwork.SaveAsync();
        return contact;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await unitofwork.Contacts.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        unitofwork.Contacts.Remove(D);
        await unitofwork.SaveAsync();
        return NoContent();
    }


   
}