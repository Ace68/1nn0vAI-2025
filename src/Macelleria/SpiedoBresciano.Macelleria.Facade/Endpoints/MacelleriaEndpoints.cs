using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace SpiedoBresciano.Macelleria.Facade.Endpoints;

public static class MacelleriaEndpoints
{
    public static IEndpointRouteBuilder MapMacelleriaEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("v1/macelleria")
            .WithTags("Macelleria");

        group.MapGet("/", () => Results.Ok("Macelleria endpoint"))
            .WithName("GetMacelleria")
            .WithSummary("Get Macelleria status")
            .WithDescription("Returns basic Macelleria status");

        return endpoints;
    }
}