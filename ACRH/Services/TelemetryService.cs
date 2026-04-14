using ACRH.Entities;
using ACRH.Repositories;

namespace ACRH.Services
{
    public unsafe class TelemetryService : ITelemetryService
    {
        private readonly ITelemetryRepository _repository;

        public TelemetryService(ITelemetryRepository repository)
        {
            _repository = repository;
        }

        // Função auxiliar para converter o ponteiro bruto do C++ (fixed) para Array do C#
        private float[] CopiarArray(float* ptr, int tamanho)
        {
            float[] arr = new float[tamanho];
            for (int i = 0; i < tamanho; i++)
            {
                arr[i] = ptr[i];
            }
            return arr;
        }

        public TelemetryData ExibirTelemetria()
        {
            try
            {
                SPageFilePhysics rawData = _repository.LerMemoriaFisica();

                return new TelemetryData()
                {
                    Acelerador = (float)Math.Round(rawData.Gas * 100),
                    Freio = (float)Math.Round(rawData.Brake  * 100),
                    Marcha = rawData.Gear - 1,

                    IdPacote = rawData.PacketId,
                    Combustivel = rawData.Fuel,
                    Rpm = rawData.Rpms,
                    AnguloEsterco = rawData.SteerAngle,
                    VelocidadeKmh = rawData.SpeedKmh,

                    Drs = rawData.Drs,
                    ControleTracao = rawData.TC,
                    Rumo = rawData.Heading,
                    Arfagem = rawData.Pitch,
                    Rolagem = rawData.Roll,
                    AlturaCentroGravidade = rawData.CGHeight,

                    QtdPneusForaPista = rawData.NumberOfTyresOut,
                    LimitadorPitStopLigado = rawData.PitLimiterOn,
                    Abs = rawData.Abs,
                    CargaKers = rawData.KersCharge,
                    EntradaKers = rawData.KersInput,
                    CambioAutomaticoLigado = rawData.AutoShifterOn,

                    Turbo = rawData.TurboBoost,
                    Lastro = rawData.Ballast,
                    DensidadeAr = rawData.AirDensity,
                    TemperaturaAr = rawData.AirTemp,
                    TemperaturaPista = rawData.RoadTemp,
                    FeedbackForcaFinal = rawData.FinalFFB,
                    MedidorPerformance = rawData.PerformanceMeter,
                    FreioMotor = rawData.EngineBrake,
                    NivelRecuperacaoErs = rawData.ErsRecoveryLevel,
                    NivelPotenciaErs = rawData.ErsPowerLevel,
                    CarregamentoCalorErs = rawData.ErsHeatCharging,
                    ErsEstaCarregando = rawData.ErsisCharging,
                    KersAtualKJ = rawData.KersCurrentKJ,
                    DrsDisponivel = rawData.DrasAvailable,
                    DrsAtivado = rawData.DrsEnabled,
                    Embreagem = rawData.Clutch,
                    ControladoPelaIA = rawData.IsAIControlled,
                    BalancoFreio = rawData.BrakeBias,

                    // Usando a nossa função auxiliar para ler a memória bruta com segurança!
                    VelocidadeVetor = CopiarArray(rawData.Velocity, 3),
                    ForcaG = CopiarArray(rawData.AccG, 3),
                    DeslizeRoda = CopiarArray(rawData.WheelSlip, 4),
                    CargaRoda = CopiarArray(rawData.WheelLoad, 4),
                    PressaoPneus = CopiarArray(rawData.WheelsPressure, 4),
                    VelocidadeAngularRoda = CopiarArray(rawData.WheelAngularSpeed, 4),
                    DesgastePneu = CopiarArray(rawData.TyreWear, 4),
                    NivelSujeiraPneu = CopiarArray(rawData.TyreDirtyLevel, 4),
                    TempNucleoPneu = CopiarArray(rawData.TyreCoreTemp, 4),
                    CambagemRad = CopiarArray(rawData.CamberRAD, 4),
                    CursoSuspensao = CopiarArray(rawData.SuspensionTravel, 4),
                    DanoCarro = CopiarArray(rawData.CarDamage, 5),
                    AlturaSolo = CopiarArray(rawData.RideHeight, 2),
                    VelocidadeAngularLocal = CopiarArray(rawData.LocalAngularVel, 3),
                    TempFreio = CopiarArray(rawData.BrakeTemp, 4),
                    TempPneuInterna = CopiarArray(rawData.TyreTempI, 4),
                    TempPneuMeio = CopiarArray(rawData.TyreTempM, 4),
                    TempPneuExterna = CopiarArray(rawData.TyreTempO, 4),
                    PontoContatoPneu = CopiarArray(rawData.TyreContactPoint, 4),
                    NormalContatoPneu = CopiarArray(rawData.TyreContactNormal, 4),
                    DirecaoContatoPneu = CopiarArray(rawData.TyreContactHeading, 4),
                    VelocidadeLocal = CopiarArray(rawData.LocalVelocity, 3)
                };
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro de telemetria: " + e.Message);
                return new TelemetryData();
            }
        }
    }
}