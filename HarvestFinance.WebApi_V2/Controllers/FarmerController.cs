using AutoMapper;
using Azure;
using HarvestFinance.Domain.Entities;
using HarvestFinance.Domain.Repositories;
using HarvestFinance.WebApi_V2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace HarvestFinance.WebApi_V2.Controllers
{
    [Route("api/farmers")]
    [ApiController]
    public class FarmerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFarmerRepository _farmerRepo;

        public FarmerController(IMapper mapper, IFarmerRepository farmerRepo)
        {
            _mapper = mapper;
            _farmerRepo = farmerRepo;
        }

        [HttpGet(Name = "GetAllFarmers")]
        public async Task<ActionResult<IEnumerable<FarmerDto>>> GetFarmers()
        {
            var farmers = await _farmerRepo.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<FarmerDto>>(farmers));
        }

        [HttpGet("{farmerId}",Name ="GetFarmer")]
        public async Task<ActionResult<FarmerDto>> GetFarmer(Guid farmerId)
        {
            var farmer = await _farmerRepo.GetAsync(farmerId);
            if (farmer is null)
                return NotFound();

            var farmerToReturn = _mapper.Map<FarmerDto>(farmer);
            return Ok(farmerToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFarmer(FarmerForCreationDto farmerToAdd)
        {
            var farmer = _mapper.Map<Farmer>(farmerToAdd);
            _farmerRepo.Add(farmer);
            await _farmerRepo.SaveAsync();
            var farmerToReturn = _mapper.Map<FarmerDto>(farmer);
            return CreatedAtAction("GetFarmer", new { farmerId = farmer.Id }, farmerToReturn);
        }

        [HttpPatch("{farmerId}")]
        public async Task<IActionResult> PartialUpdateFarmer (Guid farmerId,
            JsonPatchDocument<FarmerForPatchDto> farmerDocument)
        {
            var farmerFromRepo = await _farmerRepo.GetAsync(farmerId);
            if (farmerFromRepo is null)
            {
                return NotFound();
            }

            var farmerForPatch = _mapper.Map<FarmerForPatchDto>(farmerFromRepo);
            farmerDocument.ApplyTo(farmerForPatch);
            _mapper.Map(farmerForPatch, farmerFromRepo);
            _farmerRepo.Update(farmerFromRepo);
            await _farmerRepo.SaveAsync();
            return NoContent();
        }
    }
}
