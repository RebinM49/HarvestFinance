using HarvestFinance.Domain;
using HarvestFinance.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork ,IDisposable
    {
        private readonly HarvestFinanceDbcontext _dbcontext;
        public IFarmerRepository Farmers { get; private set; }

        public IProjectRepository Projects { get; private set; }
        public UnitOfWork(HarvestFinanceDbcontext context 
            ,IFarmerRepository farmerRepo 
            ,IProjectRepository projectRepo )
        {
            _dbcontext = context;
            Farmers = farmerRepo;
            Projects = projectRepo;
        }

        public  async Task<int> CompleteAsync()
        {
           return await _dbcontext.SaveChangesAsync();
        }

        public void Dispose()
        {
           _dbcontext.Dispose();
        }
    }
}
