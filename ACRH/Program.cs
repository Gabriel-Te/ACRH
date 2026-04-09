using ACRH.Entities;
using ACRH.Hubs;
using ACRH.Repositories;
using ACRH.Services;
using System.Runtime.Versioning;

[assembly: SupportedOSPlatform("windows")]


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ITelemetryRepository, AC_Repository>();
builder.Services.AddScoped<ITelemetryService, TelemetryService>();
builder.Services.AddSignalR();
builder.Services.AddHostedService<TelemetryWorker>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.SetIsOriginAllowed(_ => true)
              .AllowAnyMethod()
                .AllowAnyHeader()
              .WithExposedHeaders("x-requested-with", "x-signalr-user-agent")
              .AllowCredentials();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

app.MapGet("/", () => "API Ativa, Acesse /telemetria");
app.MapHub<GetTelemetryHub>("/telemetryHub");

app.Run();
