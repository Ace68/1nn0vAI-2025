using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace SpiedoBresciano.Trattoria.Facade.Endpoints;

public static class TrattoriaEndpoints
{
    public static IEndpointRouteBuilder MapTrattoriaEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("v1/trattoria")
            .WithTags("Trattoria");

        group.MapGet("/", () => Results.Ok("Trattoria endpoint"))
            .WithName("GetTrattoria")
            .WithSummary("Get Trattoria status")
            .WithDescription("Returns basic Trattoria status");

        return endpoints;
    }
}