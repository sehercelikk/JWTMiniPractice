using JwtProject.Core.Abstract;
using JwtProject.Entities.Concrete;

namespace JwtProject.DataAccess.Abstract;

public interface IUserDal : IGenericDal<AppUser>
{
}
