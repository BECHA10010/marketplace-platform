var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsEnvironment("Test"))
    builder.Configuration.AddJsonFile("appsettings.Test.json");

builder.Services
    .AddApiServices(builder.Configuration)
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

await app.UseApiServices();

app.Run();

public partial class Program { }