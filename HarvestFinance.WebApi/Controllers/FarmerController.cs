using HarvestFinance.Domain;
using HarvestFinance.Domain.Entities;
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
    public async Task<ActionResult<IEnumerable<Farmer>>> GetFarmers()
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<ActionResult<Farmer>> PostFarmer(Farmer farmer)
    {
        await _uow.Farmers.AddAsync(farmer);
        await _uow.CompleteAsync();
        return Ok(farmer);
    }
}
