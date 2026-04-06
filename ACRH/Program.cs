using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

[assembly: SupportedOSPlatform("windows")]

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "API Ativa, Acesse /telemetria");

app.MapGet("/telemetria", () =>
{
    try
    {
        using var mmf = MemoryMappedFile.OpenExisting("acpmf_physics");
        using var accessor = mmf.CreateViewAccessor();

        SPageFilePhysics dados;
        accessor.Read(0, out dados);

        // O bloco unsafe dentro da lógica evita erros de sintaxe na rota
        unsafe
        {
            return Results.Ok(new
            {
                RPM = (int)dados.Rpms,
                Velocidade = (int)dados.SpeedKmh,
                Marcha = (int)dados.Gear - 1,
                Combustivel = dados.Fuel,
                Temperaturas = new[] { dados.TyreTemp[0], dados.TyreTemp[1], dados.TyreTemp[2], dados.TyreTemp[3] }
            });
        }
    }
    catch (FileNotFoundException)
    {
        return Results.NotFound("Assetto Corsa não detectado.");
    }
    catch (Exception e)
    {
        return Results.BadRequest("Erro: " + e.Message);
    }
});

app.Run();

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public unsafe struct SPageFilePhysics
{
    public int PacketId;
    public float Gas;
    public float Brake;
    public float Fuel;
    public float Gear;
    public float Rpms;
    public float SteerAngle;
    public float SpeedKmh;
    public fixed float WheelAngularSpeed[4];
    public fixed float TyreWear[4];
    public fixed float TyreTemp[4];
}