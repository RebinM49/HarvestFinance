using HarvestFinance.Domain;
using HarvestFinance.Domain.Constants;
using HarvestFinance.Domain.Entities;
using HarvestFinance.WebApi.DTO;
using HarvestFinance.WebApi.DTO.ProjectDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.Contracts;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HarvestFinance.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        protected readonly IUnitOfWork _uow;
        public ProjectController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetProjectDto>>> GetProjects()
        {
            var projects = await _uow.Projects.GetAllAsync();
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

        private GetProjectDto MapToDto(Project project)
        {
            var dto = new GetProjectDto(
                project.Id,
                project.FarmerId,
                project.Weight,
                project.Area,
                project.Date,
                project.ProductType,
                project.HarvestType,
                project.Cost,
                project.ContractKind,
                project.Address
                );

            return dto;
        }
    }
}
