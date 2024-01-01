using HarvestFinance.Domain.Common;
using System.Linq.Expressions;


namespace HarvestFinance.Domain.Repositories;

public interface IRepository<TEntity> where TEntity : Common.Entity
{
    Task<TEntity> Get(Guid Id);
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity> Update(TEntity entity);
    Task Add(TEntity entity);
    Task Remove(TEntity entity);
}
