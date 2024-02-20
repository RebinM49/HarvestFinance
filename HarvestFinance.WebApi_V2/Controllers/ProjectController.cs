using AutoMapper;
using HarvestFinance.Domain.Repositories;
using HarvestFinance.WebApi_V2.Models;
using Microsoft.AspNetCore.Mvc;

namespace HarvestFinance.WebApi_V2.Controllers;

[Route( "api/farmers/{farmerId}/projects" )]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IProjectRepository _projectRepo;

    public ProjectController(IMapper mapper , IProjectRepository projectRepo)
    {
        _mapper = mapper;
        _projectRepo = projectRepo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProjectDto>>> GetAllProjects([FromRoute] Guid farmerId)
    {
        if (!await _projectRepo.FarmerExists( farmerId ))
        {
            return NotFound( farmerId );
        }
        var projects = await _projectRepo.GetProjectsForFarmer( farmerId );
        var projectsToReturn = _mapper.Map<IEnumerable<ProjectDto>>( projects );

        return Ok( projectsToReturn );
    }

    [HttpGet( "{projectId}" )]
    public async Task<ActionResult<ProjectDto>> GetProject(Guid farmerId , Guid projectId)
    {
        if (!await _projectRepo.FarmerExists( farmerId ))
        {
            return NotFound();
        }
        var project = await _projectRepo.GetAsync( projectId );
        if (project is null)
        {
            return NotFound();
        }
        return Ok( _mapper.Map<ProjectDto>( project ) );
    }

}
