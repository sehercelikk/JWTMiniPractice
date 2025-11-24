using JwtProject.Entities.Abstract;

namespace JwtProject.Entities.Concrete;

public class AppUser :IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
