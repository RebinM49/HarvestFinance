using AutoMapper;
using HarvestFinance.Domain.Entities;
using HarvestFinance.Domain.Repositories;
using HarvestFinance.WebApi_V2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HarvestFinance.WebApi_V2.Controllers
{
    [Route("api/projectcollections")]
    [ApiController]
    public class ProjectCollectionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProjectRepository _repository;

        public ProjectCollectionController(IMapper mapper ,
            IProjectRepository projectRepo)
        {
            _mapper = mapper;
            _repository = projectRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FullInfoProjectDto>>> GetAllProjects()
        {
            var projects =await _repository.GetCustomProjects();
            var projectsToReturn = _mapper.Map<List<FullInfoProjectDto>>(projects);
            return Ok(projectsToReturn);

        }
    }
}
