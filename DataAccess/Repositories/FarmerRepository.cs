using HarvestFinance.Domain.Entities;
using HarvestFinance.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories;

public class FarmerRepository : Repository<Farmer>, IFarmerRepository
{
    public HarvestFinanceDbcontext Dbcontext { get => _context; }
    public FarmerRepository(HarvestFinanceDbcontext context)
        : base(context) { }

    public async Task<List<Farmer>> FindFarmer(string filter)
    {
       filter = filter.ToLower();
       return await Dbcontext.Farmers
            .Where(f => f.FirstName.ToLower().Contains(filter) ||  f.LastName.ToLower().Contains(filter))
            .AsNoTracking()
            .ToListAsync();
    }
}
