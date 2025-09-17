using Grpc.Core;

namespace ReactWithDotnet.Server.Services;

public class WeatherForecastService : WeatherService.WeatherServiceBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastService> _logger;

    public WeatherForecastService(ILogger<WeatherForecastService> logger)
    {
        _logger = logger;
    }

    public override Task<WeatherResponse> GetWeatherForecast(WeatherRequest request, ServerCallContext context)
    {
        var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        });

        _logger.LogInformation("Get WeatherForecast (gRPC)");

        var response = new WeatherResponse();
        response.Forecasts.AddRange(forecasts.Select(WeatherForecast.ToProto));
        return Task.FromResult(response);
    }
}