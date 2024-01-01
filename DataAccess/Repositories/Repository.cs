using HarvestFinance.Domain.Common;
using HarvestFinance.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    protected readonly HarvestFinanceDbcontext _context;
    public Repository(HarvestFinanceDbcontext context)
    {
        _context = context;
    }

    public async Task AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
    }

    public async Task<TEntity?> GetAsync(Guid Id)
    {
        return await _context.Set<TEntity>().FindAsync(Id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
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
