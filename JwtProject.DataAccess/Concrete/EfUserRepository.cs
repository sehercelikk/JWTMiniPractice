using JwtProject.Core.Concrete;
using JwtProject.DataAccess.Abstract;
using JwtProject.DataAccess.Context;
using JwtProject.Entities.Concrete;

namespace JwtProject.DataAccess.Concrete;

public class EfUserRepository : EfGenericRepository<AppUser>, IUserDal
{
    private DataContext? context => _context as DataContext;

    public EfUserRepository(DataContext context) : base(context)
    {
    }
}
