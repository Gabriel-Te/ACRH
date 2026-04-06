using System.IO.MemoryMappedFiles;
using System.Runtime.Versioning;

[assembly: SupportedOSPlatform("windows")]

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "API Ativa, Acesse /telemetria");

app.MapGet("/telemetria", () =>
{

});

app.Run();
