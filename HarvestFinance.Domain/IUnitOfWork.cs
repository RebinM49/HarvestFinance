using HarvestFinance.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestFinance.Domain
{
    public interface IUnitOfWork
    {
        public IFarmerRepository FarmerRepository { get; }
        public IProjectRepository ProjectRepository { get; }
        public  Task<int> CompleteAsync();
    }
}
