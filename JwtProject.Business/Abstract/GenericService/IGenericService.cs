using System.Linq.Expressions;

namespace JwtProject.Business.Abstract.GenericService;

public interface IGenericService<TResult,TUpdate,TCreate>
{
    Task<List<TResult>> GetAllAsync();
    Task<TResult> GetByIdAsync(int id);
    Task CreateAsync(TCreate entity);
    Task DeleteAsync(int id);
    Task UpdateAsync(TUpdate entity);
}
