using AutoMapper;
using HarvestFinance.Domain.Entities;
using HarvestFinance.Domain.Repositories;
using HarvestFinance.WebApi_V2.Models;
using Microsoft.AspNetCore.JsonPatch;
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

    [HttpPost( "areabase" )]
    public async Task<ActionResult<ProjectDto>> AddAreaProject(Guid farmerId , AreaBaseProjectForCreationDto projectDto)
    {
        if (!await _projectRepo.FarmerExists( farmerId ))
        {
            return NotFound();
        }

        var project = CreateAreaBaseObject( projectDto , farmerId );

        _projectRepo.Add( project );
        await _projectRepo.SaveAsync();

        var projectToReturn = _mapper.Map<ProjectDto>( project );
        return CreatedAtAction( nameof( GetProject ) ,
            new { farmerId = project.FarmerId , projectId = project.Id } , projectToReturn );

    }
    [HttpPost( "sharebase" )]
    public async Task<ActionResult<ProjectDto>> AddShareProject(Guid farmerId , ShareBaseProjectForCreationDto projectDto)
    {
        if (!await _projectRepo.FarmerExists( farmerId ))
        {
            return NotFound();
        }

        var project = CreateShareBaseObject( projectDto , farmerId );

        _projectRepo.Add( project );
        await _projectRepo.SaveAsync();

        var projectToReturn = _mapper.Map<ProjectDto>( project );
        return CreatedAtAction( nameof( GetProject ) ,
            new { farmerId = project.FarmerId , projectId = project.Id } , projectToReturn );

    }
    private Project CreateAreaBaseObject(AreaBaseProjectForCreationDto projectDto , Guid farmerId)
    {
        var project = new AreaBasedProject(
            farmerId ,
            0 ,
            projectDto.Area ,
            projectDto.ProductType ,
            projectDto.HarvestType ,
            projectDto.Address ,
            projectDto.CombineName ,
            projectDto.UnitPrice );

        return project;
    }
    private Project CreateShareBaseObject(ShareBaseProjectForCreationDto projectDto , Guid farmerId)
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
            projectDto.contractRate );


        return project;
    }


    [HttpPatch( "areabase/{projectId}" )]
    public async Task<ActionResult<ProjectDto>> PartialUpdateAreaProject(Guid farmerId , 
        Guid projectId ,
        JsonPatchDocument<AreaBaseForPatchDto> patchDocument)
    {
        if (!await _projectRepo.FarmerExists( farmerId ))
        {
            return NotFound( $"farmer with this Id Dose not exists {farmerId}" );
        }

        var projectFromRepo = await _projectRepo.GetAsync( projectId );
        if (projectFromRepo is null)
        {
            return NotFound( $"Project with {projectId} Id dose not exists" );
        }

        var projectToPatch = _mapper.Map<AreaBaseForPatchDto>(projectFromRepo);
        patchDocument.ApplyTo(projectToPatch );
        _mapper.Map( projectToPatch , projectFromRepo );
        _projectRepo.Update(projectFromRepo );
        await _projectRepo.SaveAsync();
        var projectToReturnDto = _mapper.Map<ProjectDto>( projectFromRepo );
        return Ok(projectToReturnDto);

    }
}
