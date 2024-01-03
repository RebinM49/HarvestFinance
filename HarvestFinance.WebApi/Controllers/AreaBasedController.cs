using HarvestFinance.Domain;
using HarvestFinance.Domain.Entities;
using HarvestFinance.WebApi.DTO.ProjectDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace HarvestFinance.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaBasedController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public AreaBasedController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        [HttpPost]
        public async Task<IActionResult> PostAreaBasedProject(CreateAreaBasedDto createAreaDto)
        {
            var AreaBased = MapDtoToModel(createAreaDto);
            await _uow.Projects.AddAsync(AreaBased);
            await _uow.CompleteAsync();
            var result = MapModeltoDto(AreaBased);
            return Ok(result);
        }

        private AreaBasedProject MapDtoToModel(CreateAreaBasedDto dto)
        {
            var project = new AreaBasedProject(dto.FarmerId,
                0,
                dto.Area,
                dto.ProductType,
                dto.HarvestType,
                dto.Address,
                dto.CombineName,
                dto.AreaUnitPrice
                );
            return project;

        }
        private GetProjectDto MapModeltoDto(AreaBasedProject project)
        {
            var result = new GetProjectDto
                (
                    project.Id,
                    project.FarmerId,
                    project.Weight,
                    project.Area,
                    project.Date,
                    project.ProductType.ToString(),
                    project.HarvestType.ToString(),
                    project.Cost,
                    project.ContractKind.ToString(),
                    project.Address,
                    project.CombineName

                );
            return result;

        }
    }
}
