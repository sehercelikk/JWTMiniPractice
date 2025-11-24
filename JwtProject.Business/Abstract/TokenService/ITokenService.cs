using JwtProject.Dto.Concrete.UserDtos;

namespace JwtProject.Business.Abstract.TokenService;

public interface ITokenService
{
    string CreateToken(ResultUserDto user);
}
