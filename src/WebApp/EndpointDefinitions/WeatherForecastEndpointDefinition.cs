using Microsoft.AspNetCore.Mvc;
using WebApp.EndpointDefinitions.Base;
using WebApp.Services;

namespace WebApp.EndpointDefinitions;

public class WeatherForecastEndpointDefinition : IEndpointDefinition
{
    public WeatherForecastEndpointDefinition()
    {
    }

    public void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IWeatherForecastService, WeatherForecastService>();
    }

    public void RegisterEndpoints(WebApplication app)
    {
        app.MapGet("/weatherforecast",
            ([FromServices] IWeatherForecastService weatherForecastService) => Results.Ok(weatherForecastService.GetWeatherForecast()));
    }
}
