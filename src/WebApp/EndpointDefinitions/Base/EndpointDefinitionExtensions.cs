using System.Reflection;

namespace WebApp.EndpointDefinitions.Base;

public static class EndpointDefinitionExtensions
{
    public static IServiceCollection AddEndpointDefinitions(this IServiceCollection services, params Assembly[] assembliesToScan)
    {
        foreach (var assembly in assembliesToScan)
        {
            var endpointDefinitions = assembly
                .GetExportedTypes()
                .Where(type => type.IsAssignableTo(typeof(IEndpointDefinition)) && !type.IsAbstract)
                .Select(type => Activator.CreateInstance(type))
                .Cast<IEndpointDefinition>()
                .ToList();

            foreach (var endpointDefinition in endpointDefinitions)
            {
                endpointDefinition.RegisterServices(services);
            }

            services.AddSingleton(endpointDefinitions as IReadOnlyCollection<IEndpointDefinition>);
        }

        return services;
    }

    public static IApplicationBuilder UseEndpointDefinitions(this WebApplication app)
    {
        var endpointDefinitions = app.Services.GetRequiredService<IReadOnlyCollection<IEndpointDefinition>>();

        foreach (var endpointDefinition in endpointDefinitions)
        {
            endpointDefinition.RegisterEndpoints(app);
        }

        return app;
    }
}

