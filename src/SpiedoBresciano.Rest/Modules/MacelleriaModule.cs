using SpiedoBresciano.Macelleria.Facade;
using SpiedoBresciano.Macelleria.Facade.Endpoints;

namespace SpiedoBresciano.Rest.Modules;

public class MacelleriaModule : IModule
{
    public bool IsEnabled => true;
    public int Order => 0;
    
    public IServiceCollection Register(WebApplicationBuilder builder)
    {
        builder.Services.AddMacelleriaFacade();
        
        return builder.Services;
    }

    public WebApplication Configure(WebApplication app)
    {
        app.MapMacelleriaEndpoints();
        
        return app;
    }
}