using System.Text;
using ReactWithDotnet.Server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddGrpc();
builder.Services.AddProblemDetails();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseGrpcWeb();
app.MapDefaultEndpoints();

app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGrpcService<WeatherForecastService>()
   .EnableGrpcWeb();

app.MapFallbackToFile("/index.html");
app.MapDefaultControllerRoute();
app.MapGet("/", () => "This service supports gRPC, gRPC-Web, and REST clients.");
app.MapGet("/debug/routes", (IEnumerable<EndpointDataSource> endpointSources) =>
{
    var sb = new StringBuilder();
    foreach (var endpoint in endpointSources.SelectMany(es => es.Endpoints))
    {
        if (endpoint is RouteEndpoint routeEndpoint)
        {
            var methods = endpoint.Metadata
                                  .OfType<HttpMethodMetadata>()
                                  .FirstOrDefault()?.HttpMethods;

            sb.AppendLine($"{string.Join(",", methods ?? ["ANY"])} {routeEndpoint.RoutePattern.RawText}");
        }
    }
    return sb.ToString();
});

app.Run();
