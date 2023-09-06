using AutoMapper;
using Dominio;
using Dominio.Interfaces;
using Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsidenceAPI.Dtos;
using Microsoft.AspNetCore.Authorization;
using  InsidenceAPI.Helpers;
using static InsidenceAPI.Helpers.Autorizacion;
using IncidenceAPI.Helpers;
namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
 public class CountryController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public CountryController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }
/* 
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Country>>> Get()
    {
        var Con = await  unitofwork.Countries.GetAllAsync();
        return Ok(Con);
    } */

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CountryDto>>> Get()
    {
        var Con = await  _unitofwork.Countries.GetAllAsync();
        return _mapper.Map<List<CountryDto>>(Con);
    }
        
    [HttpGet]
    [MapToApiVersion("1.1")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<CountryXRegDto>>> Get11([FromQuery] Params countryParams)
    {
        var Con = await  _unitofwork.Countries.GetAllAsync(countryParams.PageIndex,countryParams.PageSize,countryParams.Search);
        var lstCountry = _mapper.Map<List<CountryXRegDto>>(Con.registros);
        return new Pager<CountryXRegDto>(lstCountry,Con.totalRegistros,countryParams.PageIndex,countryParams.PageSize,countryParams.Search);
    }



    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.Countries.GetByIdAsync(id);
        return Ok(byidC);
    }
   /*  [HttpPost]
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
 */


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Country>> Post(CountryDto countryDto){
        var country = _mapper.Map<Country>(countryDto);
        this._unitofwork.Countries.Add(country);
        await _unitofwork.SaveAsync();
        if(country == null)
        {
            return BadRequest();
        }
        countryDto.Id = country.Id.ToString();
        return CreatedAtAction(nameof(Post),new {id= countryDto.Id}, countryDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Country>> Put(int id, [FromBody]Country country){
        if(country == null)
            return NotFound();
        _unitofwork.Countries.Update(country);
        await _unitofwork.SaveAsync();
        return country;
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.Countries.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.Countries.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }
}