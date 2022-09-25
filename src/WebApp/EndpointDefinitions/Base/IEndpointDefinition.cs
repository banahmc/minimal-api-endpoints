namespace WebApp.EndpointDefinitions.Base;

public interface IEndpointDefinition
{
    void RegisterServices(IServiceCollection services);
    void RegisterEndpoints(WebApplication app);
}
