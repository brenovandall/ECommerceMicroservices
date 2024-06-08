var builder = WebApplication.CreateBuilder(args);

builder.Services
    .InjectApplicationServices()
    .InjectInfrastructureServices(builder.Configuration)
    .InjectApiServices();

var app = builder.Build();

app.UseApiServices();

app.Run();