var builder = WebApplication.CreateBuilder(args);

builder.Services
    .InjectApplicationServices()
    .InjectInfrastructureServices(builder.Configuration)
    .InjectApiServices(builder.Configuration);

var app = builder.Build();

app.UseApiServices();

if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabseAsync();
}

app.Run();