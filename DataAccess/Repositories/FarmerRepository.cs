using HarvestFinance.Domain.Entities;
using HarvestFinance.Domain.Repositories;
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
}
