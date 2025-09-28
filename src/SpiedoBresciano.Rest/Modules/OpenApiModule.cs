using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;

namespace SpiedoBresciano.Rest.Modules;

public class OpenApiModule : IModule
{
    public bool IsEnabled => true;
    public int Order => 0;

    public IServiceCollection Register(WebApplicationBuilder builder)
    {
        builder.Services.AddOpenApi(options =>
        {
            options.AddDocumentTransformer((document, _, _) =>
            {
                document.Servers = [new OpenApiServer {Url = "/"}];
                document.Info = new OpenApiInfo
                {
                    Title = "SpiedoBresciano API",
                    Version = "v1.0",
                    Description = "SpiedoBresciano API",
                    Contact = new OpenApiContact
                    {
                        Name = "SpiedoBresciano"
                    }
                };

                return Task.CompletedTask;
            });
        });

        return builder.Services;
    }

    public WebApplication Configure(WebApplication app)
    {
        app.MapOpenApi();
        app.MapScalarApiReference(options =>
        {
            options.WithTitle("SpiedoBresciano API")
                .WithTheme(ScalarTheme.None);
        });

        return app;
    }
}