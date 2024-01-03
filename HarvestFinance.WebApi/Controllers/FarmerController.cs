using HarvestFinance.Domain;
using HarvestFinance.Domain.Entities;
using HarvestFinance.WebApi.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HarvestFinance.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FarmerController : ControllerBase
{
    private readonly IUnitOfWork _uow;
    public FarmerController(IUnitOfWork unitofwork)
    {
        _uow = unitofwork;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetFarmerDto>>> GetFarmers(
        [FromQuery] int limit=5, [FromQuery] int offset=1, [FromQuery] string filter="")
    {
        IEnumerable<Farmer> farmers;
        if(!string.IsNullOrEmpty(filter))
            farmers = await _uow.Farmers.FindFarmer(filter);
        else
            farmers = await _uow.Farmers.GetAllAsync(limit, offset);
        var farmerdto = farmers.Select(f
                => new GetFarmerDto(f.Id, f.FirstName, f.LastName, f.PhoneNumber, f.Address)
                );
        return Ok(farmers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetFarmerDto>> GetFarmer(Guid id)
    {
        var farmer = await _uow.Farmers.GetAsync(id);
        if (farmer is null)
            return NotFound();
        var farmerdto = new GetFarmerDto(
            farmer.Id, farmer.FirstName, farmer.LastName, farmer.PhoneNumber, farmer.Address);
        return Ok(farmerdto);
    }

    [HttpPost]
    public async Task<ActionResult<GetFarmerDto>> PostFarmer(CreateFarmerDTO farmerDto)
    {
        Farmer farmer = new()
        {
            FirstName = farmerDto.FirstName,
            LastName = farmerDto.LastName,
            PhoneNumber = farmerDto.PhoneNumber,
            Address = farmerDto.Address
        };

        await _uow.Farmers.AddAsync(farmer);
        await _uow.CompleteAsync();
        var result = new GetFarmerDto(farmer.Id,farmer.FirstName,farmer.LastName,farmer.PhoneNumber, farmer.Address);
        return CreatedAtAction(nameof(GetFarmer), new { Id = farmer.Id },result );
    }

    [HttpPut]
    public async Task<ActionResult> PutFarmer([FromRoute]Guid id ,[FromBody]UpdateFarmerDto farmerdto)
    {
        var farmer = await _uow.Farmers.GetAsync(id);
        if (farmer is null)
            return NotFound();
        farmer.FirstName = farmerdto.firstName;
        farmer.LastName = farmerdto.lastName;
        farmer.PhoneNumber = farmerdto.phoneNumber;
        _uow.Farmers.Update(farmer);
        try
        {
            await _uow.CompleteAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            throw;
        }
        return NoContent();
    }
}
