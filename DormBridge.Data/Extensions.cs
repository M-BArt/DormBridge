using DormBridge.Application.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DormBridge.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ICommandHandler<>).Assembly;

        services.Scan(tss => tss.FromAssemblies(applicationAssembly)
            .AddClasses(itf => itf.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}