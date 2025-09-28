using SpiedoBresciano.Trattoria.Facade;
using SpiedoBresciano.Trattoria.Facade.Endpoints;

namespace SpiedoBresciano.Rest.Modules;

public class TrattoriaModule : IModule
{
    public bool IsEnabled => true;
    public int Order => 0;
    
    public IServiceCollection Register(WebApplicationBuilder builder)
    {
        builder.Services.AddTrattoriaFacade();
        
        return builder.Services;
    }

    public WebApplication Configure(WebApplication app)
    {
        app.MapTrattoriaEndpoints();
        
        return app;
    }
}