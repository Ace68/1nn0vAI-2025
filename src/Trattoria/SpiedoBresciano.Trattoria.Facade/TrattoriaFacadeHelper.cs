using Microsoft.Extensions.DependencyInjection;

namespace SpiedoBresciano.Trattoria.Facade;

public interface ITrattoriaFacade
{
}

public static class TrattoriaFacadeHelper
{
    public static IServiceCollection AddTrattoriaFacade(this IServiceCollection services)
    {
        // Register any services related to the Trattoria facade here

        // services.AddTrattoriaDomain();
        // services.AddTrattoriaInfrastructure();

        return services;
    }
}