using HarvestFinance.Domain.Common;
using HarvestFinance.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly HarvestFinanceDbcontext _context;
        public Repository(HarvestFinanceDbcontext context)
        {
            _context = context;
        }

        public async Task Add(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task<TEntity?> Get(Guid Id)
        {
            return await _context.Set<TEntity>().FindAsync(Id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public  void Update(TEntity entity)
        {
             _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
