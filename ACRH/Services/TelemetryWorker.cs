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
        var staticData = new StaticData();
        var physicsData = new PhysicsData();
        var graphicData = new GraphicData();

        bool staticIsfind = false;

        while (!stoppingToken.IsCancellationRequested)
        {
            unsafe
            {
                var rawStatic = _repository.GetStatic();
                var rawPhysics = _repository.GetPhysics();
                var rawGraphic = _repository.GetGraphic();

                if (rawStatic != null && rawPhysics != null && rawGraphic != null)
                {
                    TelemetryMapper.UpdateStatic(*rawStatic, staticData);
                    TelemetryMapper.UpdatePhysics(*rawPhysics, physicsData);
                    TelemetryMapper.UpdateGraphic(*rawGraphic, graphicData);
                }

            }
            // Enviar Static apenas uma vez (ou quando detectar mudança)

            if (staticIsfind == false)
            {
                staticIsfind = true;
            }

            // Sempre guarda/atualiza o cache estático no Hub para novos clientes pegarem via invoke
            GetTelemetryHub.UpdateStaticCache(staticData);

 
            await _hub.Clients.All.SendAsync("ReceiveStatic", new
            {
                Static = staticData
            }, stoppingToken);


            // Converter apenas os campos textuais do Graphic que vamos expor
            static string BufferToString(char[] buf)
            {
                if (buf == null) return string.Empty;
                int len = Array.IndexOf(buf, '\0');
                if (len < 0) len = buf.Length;
                return new string(buf, 0, len);
            }

            static char[] ResizedValues(char[] buf)
            {
                if (buf == null) return new char[1];
                int len = Array.IndexOf(buf, '\0');
                if (len < 0) len = buf.Length;
                var result = new char[len];
                Array.Copy(buf, result, len);
                return result;
            }

            var value = new
            {
                graphicData.IdPacote,
                graphicData.Status,
                graphicData.TipoSessao,

                graphicData.BufferCurrentTime,
                graphicData.BufferLastTime,
                graphicData.BufferBestTime,
                graphicData.BufferSplit,
                graphicData.CompletedLaps,
                graphicData.Position,
                graphicData.ICurrentTime,
                graphicData.ILastTime,
                graphicData.IBestTime,
                graphicData.SessionTimeLeft,
                graphicData.DistanceTraveled,
                graphicData.BufferTyreCompound,
                graphicData.CarCoordinates,
                graphicData.PenaltyTime,
                graphicData.Flag,
                graphicData.IdealLineOn,
                graphicData.IsInPitLane,
                graphicData.SurfaceGrip,
                graphicData.MandatoryPitDone,
                graphicData.WindSpeed,
                graphicData.WindDirection
            };
            var graphicPayload = value;

            // Envie telemetria rápida (Physics + Graphic strings)
            await _hub.Clients.All.SendAsync("ReceiveTelemetry", new
            {
                Physics = physicsData,
                Graphic = graphicPayload,
            }, stoppingToken);

            await Task.Delay(16, stoppingToken);
        }
    }
}