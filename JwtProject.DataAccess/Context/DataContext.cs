using JwtProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace JwtProject.DataAccess.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<AppUser> Users { get; set; }
}
