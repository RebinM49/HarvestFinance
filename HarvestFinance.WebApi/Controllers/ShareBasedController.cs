using HarvestFinance.Domain;
using HarvestFinance.Domain.Entities;
using HarvestFinance.WebApi.DTO.ProjectDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HarvestFinance.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShareBasedController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public ShareBasedController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpPost]
        public async Task<IActionResult> PostShareBasedProject(CreateSharedBasedDTo createSharedDto)
        {
            var sharedBased = MapDtoToModel(createSharedDto);
            _uow.Projects.Add( sharedBased );
            await _uow.CompleteAsync();
            var result = MapModeltoDto(sharedBased);
            return Ok(result);
        }

        private SharedBasedProject MapDtoToModel(CreateSharedBasedDTo dto)
        {
            var project = new SharedBasedProject(dto.FarmerId,
                dto.Weight,
                dto.Area,
                dto.ProductType,
                dto.HarvestType,
                dto.Address,
                dto.CombineName,
                dto.ProductUnitPrice,
                dto.ContractRate
                );
            return project;

        }
        private GetProjectDto MapModeltoDto(SharedBasedProject project)
        {
            var result = new GetProjectDto(
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
