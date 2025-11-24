using JwtProject.Entities.Abstract;
using System.Linq.Expressions;

namespace JwtProject.Core.Abstract;

public interface IGenericDal<T> where T: class,IEntity,new()
{
    Task<List<T>> GetAllAsync(Expression<Func<T,bool>> predicate=null, params Expression<Func<T, object>>[] includeProp);
    Task<T> GetAsync(Expression<Func<T,bool>> predicate=null, params Expression<Func<T, object>>[] includeProp);
    Task<T> GetByIdAsync(int id);
    Task<T> CreateAsync(T entity);
    Task DeleteAsync(int id);
    Task<T> UpdateAsync(T entity);
    Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
}
