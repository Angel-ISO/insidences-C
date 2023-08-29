using AutoMapper;
using Dominio;
using Dominio.Interfaces;
using Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsidenceAPI.Dtos;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

 public class RegionController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public RegionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

   [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RegionDto>>> Get()
    {
        var Con = await  _unitofwork.Regions.GetAllAsync();
        return _mapper.Map<List<RegionDto>>(Con);
    }

     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.Regions.GetByIdAsync(id);
        return Ok(byidC);
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Region>> Post(RegionDto regionDto){
        var region = _mapper.Map<Country>(regionDto);
        this._unitofwork.Countries.Add(region);
        await _unitofwork.SaveAsync();
        if(region == null)
        {
            return BadRequest();
        }
        regionDto.Id = region.Id.ToString();
        return CreatedAtAction(nameof(Post),new {id= regionDto.Id}, regionDto);
    }
    
   
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Region>> Put(int id, [FromBody]Region region){
        if(region == null)
            return NotFound();
        _unitofwork.Regions.Update(region);
        await _unitofwork.SaveAsync();
        return region;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.Regions.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.Regions.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }



}