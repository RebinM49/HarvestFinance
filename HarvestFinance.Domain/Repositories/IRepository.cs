using HarvestFinance.Domain.Common;
using System.Linq.Expressions;


namespace HarvestFinance.Domain.Repositories;

public interface IRepository<TEntity> where TEntity : Common.Entity
{
    Task<TEntity?> GetAsync(Guid Id);
    Task<IEnumerable<TEntity>> GetAllAsync(int pageSize=5,int page = 1);
    void Update(TEntity entity);
    void Add(TEntity entity);
    void Remove(TEntity entity);
    Task SaveAsync();
}
