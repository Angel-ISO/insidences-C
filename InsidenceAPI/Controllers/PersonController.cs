using AutoMapper;
using Dominio;
using Dominio.Interfaces;
using Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsidenceAPI.Dtos;
using Microsoft.AspNetCore.Authorization;
using IncidenceAPI.Helpers;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
 public class PersonController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public PersonController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

  /*   [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Place>>> Get()
    {
        var Con = await  unitofwork.Persons.GetAllAsync();
        return Ok(Con);
    } */

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonDto>>> Get()
    {
        var Con = await  _unitofwork.Persons.GetAllAsync();
        return Ok(Con);
    }


          
    [HttpGet]
    [MapToApiVersion("1.1")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<PersonxIncidenceDto>>> Get11([FromQuery] Params personParams)
    {
        var Per = await  _unitofwork.Persons.GetAllAsync(personParams.PageIndex,personParams.PageSize,personParams.Search);
        var lstPerson = _mapper.Map<List<PersonxIncidenceDto>>(Per.registros);
        return new Pager<PersonxIncidenceDto>(lstPerson,Per.totalRegistros,personParams.PageIndex,personParams.PageSize,personParams.Search);
    }


     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.Persons.GetByIdAsync(id);
        return Ok(byidC);
    }

  /*   [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Person>> Post(Person person){
        this._unitofwork.Persons.Add(person);
        await _unitofwork.SaveAsync();
        if(person == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= person.Id}, person);
    } */

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Person>> Post(PersonDto personDto){
        var person = _mapper.Map<Person>(personDto);
        this._unitofwork.Persons.Add(person);
        await _unitofwork.SaveAsync();
        if(person == null)
        {
            return BadRequest();
        }
        personDto.SuIdDeDocumento = person.Id;
        return CreatedAtAction(nameof(Post),new {id= personDto.SuIdDeDocumento}, personDto);
    }




     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Person>> Put(int id, [FromBody]Person person){
        if(person == null)
            return NotFound();
        _unitofwork.Persons.Update(person);
        await _unitofwork.SaveAsync();
        return person;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.Persons.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.Persons.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }


   
}