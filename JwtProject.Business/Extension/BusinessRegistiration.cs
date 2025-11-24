using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System.Reflection;

namespace JwtProject.Business.Extension;

public static class BusinessRegistiration
{
    public static void AddBusinessService(this IServiceCollection service)
    {
        service.Scan(opt =>
        {
            opt.FromAssemblies(Assembly.GetExecutingAssembly())
            .AddClasses(publicOnly: false)
            .UsingRegistrationStrategy(registrationStrategy: RegistrationStrategy.Skip)
            .AsMatchingInterface()
            .AsImplementedInterfaces()
            .WithScopedLifetime();
        });

    }
}
