using HarvestFinance.Domain.Common;
using System.Linq.Expressions;


namespace HarvestFinance.Domain.Repositories;

public interface IRepository<TEntity> where TEntity : Common.Entity
{
    Task<TEntity?> GetAsync(Guid Id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    void Update(TEntity entity);
    Task AddAsync(TEntity entity);
    void Remove(TEntity entity);
}
