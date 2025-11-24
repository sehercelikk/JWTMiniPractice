using AutoMapper;
using JwtProject.Business.Abstract.UserService;
using JwtProject.DataAccess.Abstract;
using JwtProject.Dto.Concrete.UserDtos;
using JwtProject.Entities.Concrete;

namespace JwtProject.Business.Concrete.UserService;

public class UserService : IUserService
{
    private readonly IUserDal _userDal;
    private readonly IMapper _mapper;

    public UserService(IUserDal userDal, IMapper mapper)
    {
        _userDal = userDal;
        _mapper = mapper;
    }

    public async Task CreateAsync(RegisterUserDto entity)
    {
        var kontrol = await _userDal.AnyAsync(a => a.Email == entity.Email);
        if (kontrol)
        {
            throw new Exception("Email zaten kayıtlı.");
        }
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(entity.PasswordHash);
        if(entity.PasswordHash != entity.ConfirmPassword)
        {
            throw new Exception("Parolalar eşleşmiyor.");
        }
        var user = new AppUser
        {
            Email = entity.Email,
            Name = entity.Name,
            Surname = entity.Surname,
            PasswordHash = passwordHash,
            CreatedDate = DateTime.Now,
        };
        await _userDal.CreateAsync(user);
    }

    public async Task DeleteAsync(int id)
    {
        await _userDal.DeleteAsync(id);
    }

    public async Task<List<ResultUserDto>> GetAllAsync()
    {
        var result = await _userDal.GetAllAsync();
        return _mapper.Map<List<ResultUserDto>>(result);
    }

    public async Task<ResultUserDto> GetByIdAsync(int id)
    {
        var result = await _userDal.GetByIdAsync(id);
        return _mapper.Map<ResultUserDto>(result);
    }


    public async Task<ResultUserDto> LoginAsync(LoginDto loginDto)
    {
        var findUser = await _userDal.GetAsync(a=>a.Email == loginDto.Email);
        if (findUser == null)
        {
            throw new Exception("Kullanıcı bulunamadı.");
        }
        bool passwordCheck = BCrypt.Net.BCrypt.Verify(loginDto.PasswordHash, findUser.PasswordHash);
        if (!passwordCheck)
            throw new Exception("Email veya şifre hatalı.");
        return _mapper.Map<ResultUserDto>(findUser);
    }

    public async Task<ResultUserDto> GetByEmailAsync(string email)
    {
        var user = await _userDal.GetAsync(a => a.Email == email);
        return _mapper.Map<ResultUserDto>(user);
    }

    public Task UpdateAsync(UpdateUserDto entity)
    {
        var mapEntity = _mapper.Map<AppUser>(entity);
        return _userDal.UpdateAsync(mapEntity);
    }

  
}
