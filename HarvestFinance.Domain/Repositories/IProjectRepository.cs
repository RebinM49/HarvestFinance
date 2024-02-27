using HarvestFinance.Domain.Entities;
using HarvestFinance.Domain.Models;


namespace HarvestFinance.Domain.Repositories;

public interface IProjectRepository : IRepository<Project>
{
    Task<IEnumerable<CustomProjectDto>> GetCustomProjects();
    Task<IEnumerable<Project>> GetProjectsForFarmer( Guid farmerId );
    Task<bool> FarmerExists( Guid farmerId );
}
