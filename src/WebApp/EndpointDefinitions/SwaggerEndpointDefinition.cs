using Microsoft.OpenApi.Models;
using WebApp.EndpointDefinitions.Base;

namespace WebApp.EndpointDefinitions;

public class SwaggerEndpointDefinition : IEndpointDefinition
{
    public void RegisterServices(IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Simple Minimal Api", Version = "v1" });
        });
    }

    public void RegisterEndpoints(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Simple Minimal Api");
        });
    }
}
