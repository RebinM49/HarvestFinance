using HarvestFinance.Domain.Entities;
using HarvestFinance.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories;

public class ProjectRepository : Repository<Project>, IProjectRepository
{
    public HarvestFinanceDbcontext Dbcontext { get => _context; }
    public ProjectRepository(HarvestFinanceDbcontext context)
        : base(context) { }

    public async Task<List<Project>> Findproject(string filter)
    {
        filter = filter.ToLower();
        return await Dbcontext
            .Projects
            .Where(p 
                => p.ProductType.ToString().ToLower().Contains(filter) 
                || p.HarvestType.ToString().ToLower().Contains(filter))
            .AsNoTracking()
            .ToListAsync();
    }
}
