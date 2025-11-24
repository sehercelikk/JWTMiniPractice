using JwtProject.Core.Abstract;
using JwtProject.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JwtProject.Core.Concrete;

public class EfGenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class, IEntity, new()
{
    protected readonly DbContext _context;

    public EfGenericRepository(DbContext context)
    {
        _context = context;
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProp)
    {
        IQueryable<TEntity> query= _context.Set<TEntity>();
        if(predicate != null)
        {
            query = query.Where(predicate);
        }
        if(includeProp !=null)
        {
            foreach(var include in includeProp)
            {
                query = query.Include(include);
            }
        }
        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        var findId = await _context.Set<TEntity>().FindAsync(id);
        return findId;
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await _context.Set<TEntity>().AnyAsync(filter);
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var findId= await _context.Set<TEntity>().FindAsync(id);
        _context.Remove(findId);
        await _context.SaveChangesAsync();
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProp)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>();
        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        if (includeProp != null)
        {
            if (includeProp.Any())
            {
                foreach (var includeProperty in includeProp)
                {
                    query = query.Include(includeProperty);
                }
            }
        }
        return await query.AsNoTracking().FirstOrDefaultAsync();
    }
}
