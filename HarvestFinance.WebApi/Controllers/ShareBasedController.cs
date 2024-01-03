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
        public async Task<IActionResult> PostShareBasedProject(CreateSharedBasedDTo  createSharedDto)
        {
            var sharedBasedProject = MapDtoToModel(createSharedDto);
            await _uow.Projects.AddAsync(sharedBasedProject);
            await _uow.CompleteAsync();
            return CreatedAtAction(nameof(ProjectController.GetProject),new {id =  sharedBasedProject.Id},createSharedDto);
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
    }
}
