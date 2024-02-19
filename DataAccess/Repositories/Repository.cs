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

    public async void Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }

    public async Task<TEntity?> GetAsync(Guid Id)
    {
        return await _context.Set<TEntity>().FindAsync(Id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(int pageSize, int page)
    {
        return await _context.Set<TEntity>().Skip((page-1)*pageSize).Take(pageSize).AsNoTracking().ToListAsync();
    }

    public void Remove(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public void Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
