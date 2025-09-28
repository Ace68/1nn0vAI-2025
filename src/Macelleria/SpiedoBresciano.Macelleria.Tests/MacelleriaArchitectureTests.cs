using System.Diagnostics.CodeAnalysis;
using SpiedoBresciano.Macelleria.Facade;
using NetArchTest.Rules;

namespace SpiedoBresciano.Macelleria.Tests;

[ExcludeFromCodeCoverage]
public class MacelleriaArchitectureTests
{
    [Fact]
    public void Should_MacelleriaArchitecture_BeCompliant()
    {
        var types = Types.InAssembly(typeof(MacelleriaFacadeHelper).Assembly);

        var forbiddenAssemblies = new List<string>
        {
            "SpiedoBresciano.Trattoria.Domain",
            "SpiedoBresciano.Trattoria.Facade",
            "SpiedoBresciano.Trattoria.Infrastructure",
            "SpiedoBresciano.Trattoria.ReadModel",
            "SpiedoBresciano.Trattoria.SharedKernel"
        };
        
        var result = types
            .ShouldNot()
            .HaveDependencyOnAny(forbiddenAssemblies.ToArray())
            .GetResult()
            .IsSuccessful;

        Assert.True(result, "Macelleria module should not have dependencies on Trattoria module");
    }
    
    [Fact]
    public void MacelleriaProjects_Should_Have_Namespace_StartingWith_Macelleria()
    {
        var types = Types.InAssembly(typeof(MacelleriaFacadeHelper).Assembly);
        
        var result = types
            .Should()
            .HaveNameStartingWith("SpiedoBresciano.Macelleria")
            .GetResult()
            .IsSuccessful;
            
        Assert.True(result, "All types in Macelleria module should have namespace starting with SpiedoBresciano.Macelleria");
    }
}