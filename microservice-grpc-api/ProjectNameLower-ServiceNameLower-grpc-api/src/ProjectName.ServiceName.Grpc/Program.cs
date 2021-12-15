using Ion;
using Ion.MicroServices;
using Ion.MicroServices.Grpc;
using Microsoft.Extensions.Logging.Abstractions;
using ProjectName.ServiceName.Grpc.Services;
using ProjectName.ServiceName.Grpc.Weather;

var service = new MicroService("ProjectNameLower-ServiceNameLower-grpc-api", new NullLogger<IMicroService>())
    .ConfigureServices(services =>
    {
        services.AddSingleton<IWeatherForecastService, WeatherForecastService>();
    })
    .ConfigureGrpcCodeFirstPipeline(endpoints => {
        endpoints.MapGrpcService<WeatherForecastingService>();
    });

await service.RunAsync();