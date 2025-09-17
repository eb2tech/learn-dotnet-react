namespace ReactWithDotnet.Server;

public class WeatherForecast
{
    public static WeatherData ToProto(WeatherForecast forecast)
    {
        return new WeatherData
        {
            Date = forecast.Date.ToString("yyyy-MM-dd"),
            TemperatureC = forecast.TemperatureC,
            TemperatureF = forecast.TemperatureF,
            Summary = forecast.Summary ?? string.Empty
        };
    }

    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    public string? Summary { get; set; }
}