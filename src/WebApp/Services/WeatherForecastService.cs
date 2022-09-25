using WebApp.Models;

namespace WebApp.Services;

public interface IWeatherForecastService
{
    IEnumerable<WeatherForecast> GetWeatherForecast();
}

public class WeatherForecastService : IWeatherForecastService
{
    public IEnumerable<WeatherForecast> GetWeatherForecast()
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        var forecast = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
            .ToArray();
        return forecast;
    }
}

