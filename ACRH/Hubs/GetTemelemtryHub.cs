using Microsoft.AspNetCore.SignalR;
namespace ACRH.Hubs;

public class GetTelemetryHub : Hub
{
    private static object? _cachedStatic;



    public async Task RequestStaticData()
    {
        if (_cachedStatic != null)
        {
            await Clients.Caller.SendAsync("ReceiveStatic", new { Static = _cachedStatic });
        }
    }

    public static void UpdateStaticCache(object staticData)
    {
        _cachedStatic = staticData;
    }
}