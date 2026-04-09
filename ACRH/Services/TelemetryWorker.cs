using ACRH.Hubs;
using ACRH.Services;
using Microsoft.AspNetCore.SignalR;

public class TelemetryWorker : BackgroundService
{
    private readonly IHubContext<GetTelemetryHub> _hub;
    private readonly IServiceProvider _serviceProvider;

    public TelemetryWorker(IHubContext<GetTelemetryHub> hub, IServiceProvider serviceProvider)
    {
        _hub = hub;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<ITelemetryService>();
                var data = service.ExibirTelemetria();

                await _hub.Clients.All.SendAsync("ReceiveTelemetry", data, stoppingToken);
            }
            await Task.Delay(16, stoppingToken); // 60 FPS
        }
    }
}