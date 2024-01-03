using HarvestFinance.Domain.Constants;
using HarvestFinance.Domain.Entities;
using HarvestFinance.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class ProjectRepository : Repository<Project>, IProjectRepository
{
    public HarvestFinanceDbcontext Dbcontext { get => _context; }
    public ProjectRepository(HarvestFinanceDbcontext context)
        : base(context) { }
}
