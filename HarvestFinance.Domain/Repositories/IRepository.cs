using HarvestFinance.Domain.Common;
using System.Linq.Expressions;


namespace HarvestFinance.Domain.Repositories;

 public interface IRepository<TEntity> where TEntity : Common.Entity
    {
        Task<TEntity> Get(Guid Id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task Add(TEntity entity);
        Task Remove(TEntity entity);
    }
