using HarvestFinance.Domain.Entities;
using HarvestFinance.Domain;
using HarvestFinance.Domain.Models;
using System;
using System.Collections.Generic;


namespace HarvestFinance.Domain.Repositories;

public interface IProjectRepository : IRepository<Project>
{
    Task<IEnumerable<CustomProjectDto>> GetCustomProjects();
}
