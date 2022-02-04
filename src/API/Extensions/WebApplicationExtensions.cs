using WebApi101.API.FeatureModules;

namespace WebApi101.API.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication MapEndpoints(
        this WebApplication webApplication)
    {
        var modules =
            DiscoverModules();

        foreach (var module in modules)
            module.MapEndpoints(webApplication);

        return
            webApplication;
    }

    private static IEnumerable<IFeatureModule> DiscoverModules()
    {
        return typeof(IFeatureModule).Assembly
            .GetTypes()
            .Where(p => p.IsClass && p.IsAssignableTo(typeof(IFeatureModule)))
            .Select(Activator.CreateInstance)
            .Cast<IFeatureModule>();
    }
}
