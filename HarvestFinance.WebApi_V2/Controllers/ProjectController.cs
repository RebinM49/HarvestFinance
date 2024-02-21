using AutoMapper;
using HarvestFinance.Domain.Entities;
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

    [HttpGet( "{projectId}" , Name = "GetProjectForFarmer" )]
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

    [HttpPost]
    public async Task<ActionResult<ProjectDto>> AddProject(Guid farmerId , ProjectForCreationDto projectDto)
    {
        if (!await _projectRepo.FarmerExists( farmerId ))
        {
            return NotFound();
        }

        var project = ConditionalAdd( projectDto , farmerId );
        project.FarmerId = farmerId;
        _projectRepo.Add( project );
        await _projectRepo.SaveAsync();
        var projectToReturn = _mapper.Map<ProjectDto>( project );

        return CreatedAtAction( nameof( GetProject ) ,
            new { farmerId = project.FarmerId , projectId = project.Id } , projectToReturn );

    }

    private Project ConditionalAdd(ProjectForCreationDto projectDto , Guid farmerId)
    {
        //  TODO : Needs a projectResult type which has the project property and a Result Property
        if (projectDto.ContractKind == Domain.Constants.ContractType.AreaBased)
        {
            var project = new AreaBasedProject(
                farmerId ,
                projectDto.Weight ,
                projectDto.Area ,
                projectDto.ProductType ,
                projectDto.HarvestType ,
                projectDto.Address ,
                projectDto.CombineName ,
                projectDto.UnitPrice );

            return project;

        }
        else
        {
            var project = new SharedBasedProject(
                farmerId ,
                projectDto.Weight ,
                projectDto.Area ,
                projectDto.ProductType ,
                projectDto.HarvestType ,
                projectDto.Address ,
                projectDto.CombineName ,
                projectDto.UnitPrice ,
                0.05);

            return project;

        }
    }


}
