using AutoMapper;
using HarvestFinance.Domain.Repositories;
using HarvestFinance.WebApi_V2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HarvestFinance.WebApi_V2.Controllers
{
    [Route("api/farmers")]
    [ApiController]
    public class FarmerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFarmerRepository _farmerRepo;

        public FarmerController(IMapper mapper,IFarmerRepository farmerRepo)
        {
            _mapper = mapper;
            _farmerRepo = farmerRepo;
        }

        [HttpGet(Name ="GetAllFarmers")]
        public async Task<ActionResult<IEnumerable<FarmerDto>>> GetFarmers()
        {
            var farmers = await _farmerRepo.GetAllAsync();
            
            return Ok(_mapper.Map<IEnumerable<FarmerDto>>(farmers));
        }


    }
}
