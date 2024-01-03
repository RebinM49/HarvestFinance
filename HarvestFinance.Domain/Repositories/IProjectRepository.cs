using HarvestFinance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestFinance.Domain.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<List<Project>> Findproject(string filter);
    }
}
