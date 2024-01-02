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
    public class AreaBasedController : ProjectController
    {
        public AreaBasedController(IUnitOfWork uow) : base(uow)
        {
        }
        [HttpPost]
        public async Task<ActionResult<GetProjectDto>> PostAreaBasedProject(CreateAreaBasedDto createAreaDto)
        {
            var AreaBased = MapDtoToModel(createAreaDto);
            await _uow.Projects.AddAsync(AreaBased);
            await _uow.CompleteAsync();
            return CreatedAtAction(nameof(GetProject), new { Id = AreaBased.Id },AreaBased);
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
    }
}
