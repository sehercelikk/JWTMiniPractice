using JwtProject.Business.Abstract.GenericService;
using JwtProject.Dto.Concrete.UserDtos;

namespace JwtProject.Business.Abstract.UserService;

public interface IUserService : IGenericService<ResultUserDto,UpdateUserDto,RegisterUserDto>
{
    Task<ResultUserDto> LoginAsync(LoginDto loginDto);
    Task<ResultUserDto> GetByEmailAsync(string email);
}
