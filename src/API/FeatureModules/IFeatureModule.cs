namespace WebApi101.API.FeatureModules;

public interface IFeatureModule
{
    IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpointRouteBuilder);
    IServiceCollection RegisterModule(IServiceCollection services);
}