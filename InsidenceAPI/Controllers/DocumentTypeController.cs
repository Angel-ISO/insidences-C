using AutoMapper;
using Dominio;
using Dominio.Interfaces;
using Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

 public class DocumentTypeController : BaseApiController
{

     private readonly IUnitOfWork unitofwork;
     private readonly IMapper mapper;

    public DocumentTypeController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DocumentType>>> Get()
    {
        var Con = await  unitofwork.DocumentTypes.GetAllAsync();
        return Ok(Con);
    }

     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  unitofwork.DocumentTypes.GetByIdAsync(id);
        return Ok(byidC);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DocumentType>> Post(DocumentType documentType){
        this.unitofwork.DocumentTypes.Add(documentType);
        await unitofwork.SaveAsync();
        if(documentType == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= documentType.Id}, documentType);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DocumentType>> Put(int id, [FromBody]DocumentType documentType){
        if(documentType == null)
            return NotFound();
        unitofwork.DocumentTypes.Update(documentType);
        await unitofwork.SaveAsync();
        return documentType;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await unitofwork.DocumentTypes.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        unitofwork.DocumentTypes.Remove(D);
        await unitofwork.SaveAsync();
        return NoContent();
    }


   
}