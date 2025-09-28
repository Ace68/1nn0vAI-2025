using System.Diagnostics.CodeAnalysis;
using SpiedoBresciano.Trattoria.Facade;
using NetArchTest.Rules;

namespace SpiedoBresciano.Trattoria.Tests;

[ExcludeFromCodeCoverage]
public class TrattoriaArchitectureTests
{
    [Fact]
    public void Should_TrattoriaArchitecture_BeCompliant()
    {
        var types = Types.InAssembly(typeof(TrattoriaFacadeHelper).Assembly);

        var forbiddenAssemblies = new List<string>
        {
            "SpiedoBresciano.Macelleria.Domain",
            "SpiedoBresciano.Macelleria.Facade",
            "SpiedoBresciano.Macelleria.Infrastructure",
            "SpiedoBresciano.Macelleria.ReadModel",
            "SpiedoBresciano.Macelleria.SharedKernel"
        };
        
        var result = types
            .ShouldNot()
            .HaveDependencyOnAny(forbiddenAssemblies.ToArray())
            .GetResult()
            .IsSuccessful;

        Assert.True(result, "Trattoria module should not have dependencies on Macelleria module");
    }
    
    [Fact]
    public void TrattoriaProjects_Should_Have_Namespace_StartingWith_Trattoria()
    {
        var types = Types.InAssembly(typeof(TrattoriaFacadeHelper).Assembly);
        
        var result = types
            .Should()
            .HaveNameStartingWith("SpiedoBresciano.Trattoria")
            .GetResult()
            .IsSuccessful;
            
        Assert.True(result, "All types in Trattoria module should have namespace starting with SpiedoBresciano.Trattoria");
    }
}