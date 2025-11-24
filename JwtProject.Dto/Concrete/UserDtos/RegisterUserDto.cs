namespace JwtProject.Dto.Concrete.UserDtos;

public class RegisterUserDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string ConfirmPassword { get; set; }
}
