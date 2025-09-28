using Microsoft.Extensions.DependencyInjection;

namespace SpiedoBresciano.Macelleria.Facade;

public interface IMacelleriaFacade
{
}

public static class MacelleriaFacadeHelper
{
    public static IServiceCollection AddMacelleriaFacade(this IServiceCollection services)
    {
        // Register any services related to the Macelleria facade here

        // services.AddMacelleriaDomain();
        // services.AddMacelleriaInfrastructure();

        return services;
    }
}