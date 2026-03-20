using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

builder.Services
    .AddApiServices(builder.Configuration)
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

await app.ConfigureApiAsync();

app.Run();

public partial class Program { }