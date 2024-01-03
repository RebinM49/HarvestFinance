using HarvestFinance.Domain;
using HarvestFinance.Domain.Constants;
using HarvestFinance.Domain.Entities;
using HarvestFinance.WebApi.DTO;
using HarvestFinance.WebApi.DTO.ProjectDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace HarvestFinance.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class ProjectController : ControllerBase
{
    protected readonly IUnitOfWork _uow;
    public ProjectController(IUnitOfWork uow)
    {
        _uow = uow;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetProjectDto>>> GetProjects(
          [FromQuery] int limit = 5, [FromQuery] int offset = 1)
    {
        var projects = await _uow.Projects.GetAllAsync(limit, offset);
        var projectDto = projects.Select(p => MapToDto(p));
        return Ok(projectDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetProjectDto>> GetProject(Guid id)
    {
        var project = await _uow.Projects.GetAsync(id);
        if (project is null)
            return NotFound();
        var dto = MapToDto(project);
        return Ok(dto);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProject(Guid id)
    {
        var project = await _uow.Projects.GetAsync(id);
        if (project is null)
            return NotFound();
        _uow.Projects.Remove(project);
        await _uow.CompleteAsync();
        return Ok();
    }

    private GetProjectDto MapToDto(Project project)
    {
        var dto = new GetProjectDto(
            project.Id,
            project.FarmerId,
            project.Weight,
            project.Area,
            project.Date,
            project.ProductType.ToString(),
            project.HarvestType.ToString(),
            project.Cost,
            project.ContractKind.ToString(),
            project.Address
            );

        return dto;
    }
}
