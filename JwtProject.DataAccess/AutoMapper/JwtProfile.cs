using AutoMapper;
using JwtProject.Dto.Concrete.UserDtos;
using JwtProject.Entities.Concrete;

namespace JwtProject.DataAccess.AutoMapper;

public class JwtProfile : Profile
{
    public JwtProfile()
    {
       
        CreateMap<ResultUserDto, AppUser>().ReverseMap();
        CreateMap<RegisterUserDto, AppUser>().ReverseMap();
        CreateMap<UpdateUserDto, AppUser>().ReverseMap();

    }
}
