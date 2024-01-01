using HarvestFinance.Domain.Common;
using System.Linq.Expressions;


namespace HarvestFinance.Domain.Repositories;

 public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity Get(Guid Id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void Remove(TEntity entity);
    }
