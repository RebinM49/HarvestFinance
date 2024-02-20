using HarvestFinance.Domain.Constants;
using HarvestFinance.Domain.Entities;
using HarvestFinance.Domain.Models;
using HarvestFinance.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class ProjectRepository : Repository<Project>, IProjectRepository
{
    public HarvestFinanceDbcontext Dbcontext { get => _context; }
    public ProjectRepository(HarvestFinanceDbcontext context)
        : base(context) { }

    public async Task<IEnumerable<CustomProjectDto>> GetCustomProjects()
    {
        IQueryable<CustomProjectDto> projects =
            from project in Dbcontext.Projects
            join farmer in Dbcontext.Farmers
            on project.FarmerId equals farmer.Id
            select new CustomProjectDto
            {
                Id = project.Id,
                FarmerId = farmer.Id,
                FarmerInfo = $"{farmer.FirstName} {farmer.LastName}",
                Date = project.Date,
                Address =project.Address,
                Area    =project.Area,
                Weight = project.Weight,
                CombineName =project.CombineName,
                ContractKind = project.ContractKind.ToString(),
                HarvestType = project.HarvestType.ToString(),
                ProductType = project.ProductType.ToString(),
                Cost = project.Cost
            };

        
        return await projects.AsNoTracking().ToListAsync();
    }
}
