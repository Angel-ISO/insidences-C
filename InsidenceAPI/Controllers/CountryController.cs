using AutoMapper;
using Dominio;
using Dominio.Interfaces;
using Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

 public class GenreController : BaseApiController
{

     private readonly IUnitOfWork unitofwork;
     private readonly IMapper mapper;

    public GenreController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Country>>> Get()
    {
        var Gen = await  unitofwork.Countries.GetAllAsync();
        return Ok(Gen);
    }
     [HttpGet("id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidGenre = await  unitofwork.Countries.GetByIdAsync(id);
        return Ok(byidGenre);
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


}