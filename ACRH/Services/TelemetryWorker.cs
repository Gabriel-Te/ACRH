using ACRH.Hubs;
using ACRH.Repositories;
using ACRH.DTOs; // Certifique-se de importar seus DTOs
using ACRH.Entities;
using Microsoft.AspNetCore.SignalR;

public class TelemetryWorker : BackgroundService
{
    private readonly IHubContext<GetTelemetryHub> _hub;
    private readonly ITelemetryRepository _repository; // Use a interface

    public TelemetryWorker(IHubContext<GetTelemetryHub> hub, ITelemetryRepository repository)
    {
        _hub = hub;
        _repository = repository;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // 1. Inicialize seus DTOs (Managed Memory) FORA do loop
        var staticData = new StaticData();
        var physicsData = new PhysicsData();
        var graphicData = new GraphicData();

        // 2. Loop principal
        while (!stoppingToken.IsCancellationRequested)
        {
            // --- BLOCO UNSAFE (Leitura Rápida) ---
            unsafe
            {
                var rawStatic = _repository.GetStatic();
                var rawPhysics = _repository.GetPhysics();
                var rawGraphic = _repository.GetGraphic();


                // Verifica se os ponteiros são válidos (O jogo deve estar aberto)
                if (rawStatic != null && rawPhysics != null && rawGraphic != null)
                {
                    // Mapeia para objetos "Managed" (C# normal)
                    TelemetryMapper.UpdateStatic(*rawStatic, staticData);
                    TelemetryMapper.UpdatePhysics(*rawPhysics, physicsData);
                    TelemetryMapper.UpdateGraphic(*rawGraphic, graphicData);
                    var splitString = new string(graphicData.BufferSplit).TrimEnd('\0');

                    // Isso vai imprimir no seu terminal de execução do .NET
                    Console.WriteLine($"[DEBUG] Split lido: '{splitString}' | Tamanho: {splitString.Length}");
                }

            }
            
            // --- O BLOCO UNSAFE TERMINA AQUI ---
             


            // 3. BLOCO SAFE (Envio de rede)
            // Agora que os DTOs estão populados, fazemos o await com segurança.
            await _hub.Clients.All.SendAsync("ReceiveTelemetry", new
            {
                Physics = physicsData,
                Graphic = graphicData,
                Static = staticData
            }, stoppingToken);

            // Controle de FPS
            await Task.Delay(16, stoppingToken);
        }
    }
}