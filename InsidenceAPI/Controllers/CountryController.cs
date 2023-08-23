using AutoMapper;
using Dominio;
using Dominio.Interfaces;
using Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

 public class CountryController : BaseApiController
{

     private readonly IUnitOfWork unitofwork;
     private readonly IMapper mapper;

    public CountryController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Country>>> Get()
    {
        var Con = await  unitofwork.Countries.GetAllAsync();
        return Ok(Con);
    }
     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  unitofwork.Countries.GetByIdAsync(id);
        return Ok(byidC);
    }
 [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Country>> Post(Country country){
        this.unitofwork.Countries.Add(country);
        await unitofwork.SaveAsync();
        if(country == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= country.Id}, country);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Country>> Put(int id, [FromBody]Country country){
        if(country == null)
            return NotFound();
        unitofwork.Countries.Update(country);
        await unitofwork.SaveAsync();
        return country;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await unitofwork.Countries.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        unitofwork.Countries.Remove(D);
        await unitofwork.SaveAsync();
        return NoContent();
    }
    

}