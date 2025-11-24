using JwtProject.DataAccess.AutoMapper;
using JwtProject.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System.Reflection;

namespace JwtProject.DataAccess.Extension;

public static class DalRegistiration
{
    public static void AddRepositoryExtension(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(opt =>
        {
            //Connection stringi gizlilikten ötürü Screts.Json dosyasından alıyoruz çünkü projeyi github a push ladığımda otomatik olarak bu dosyayı local de tutuyor.
            opt.UseSqlServer(configuration.GetConnectionString("ConnectionString"));
            //Lazy Loading Kullanmak için gerekli ayar
            opt.UseLazyLoadingProxies();
        });

        services.AddAutoMapper(typeof(JwtProfile).Assembly);

        //Servis kayıtlarını otomatik yapması için.
        // services.AddScopped<IUserDal,EfUserRepository>(); gibi
        services.Scan(opt =>
        {
            opt.FromAssemblies(Assembly.GetExecutingAssembly())
            .AddClasses(classes=>classes.Where(c=>c.Name.Contains("Ef")))
            .UsingRegistrationStrategy(registrationStrategy: RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .AsMatchingInterface()
            .WithScopedLifetime();
        });
    }
}
