using HarvestFinance.Domain.Common;
using System.Linq.Expressions;


namespace HarvestFinance.Domain.Repositories;

public interface IRepository<TEntity> where TEntity : Common.Entity
{
    Task<TEntity?> Get(Guid Id);
    Task<IEnumerable<TEntity>> GetAll();
    void Update(TEntity entity);
    Task Add(TEntity entity);
    void Remove(TEntity entity);
}
