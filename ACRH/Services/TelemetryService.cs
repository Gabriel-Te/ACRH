using ACRH.Entities;
using ACRH.Repositories;
using ACRH.Services.Interfaces;

namespace ACRH.Services
{
    public unsafe class TelemetryService : ITelemetryService
    {
        private readonly ITelemetryRepository _repository;

        public TelemetryService(ITelemetryRepository repository)
        {
            _repository = repository;
        }

        private float[] CopyArray(float* ptr, int tamanho)
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
                    Acelerador = rawData.Gas,
                    Freio = rawData.Brake,
                    Marcha = rawData.Gear,
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

                    VelocidadeVetor = CopyArray(rawData.Velocity, 3),
                    ForcaG = CopyArray(rawData.AccG, 3),
                    DeslizeRoda = CopyArray(rawData.WheelSlip, 4),
                    CargaRoda = CopyArray(rawData.WheelLoad, 4),
                    PressaoPneus = CopyArray(rawData.WheelsPressure, 4),
                    VelocidadeAngularRoda = CopyArray(rawData.WheelAngularSpeed, 4),
                    DesgastePneu = CopyArray(rawData.TyreWear, 4),
                    NivelSujeiraPneu = CopyArray(rawData.TyreDirtyLevel, 4),
                    TempNucleoPneu = CopyArray(rawData.TyreCoreTemp, 4),
                    CambagemRad = CopyArray(rawData.CamberRAD, 4),
                    CursoSuspensao = CopyArray(rawData.SuspensionTravel, 4),
                    DanoCarro = CopyArray(rawData.CarDamage, 5),
                    AlturaSolo = CopyArray(rawData.RideHeight, 2),
                    VelocidadeAngularLocal = CopyArray(rawData.LocalAngularVel, 3),
                    TempFreio = CopyArray(rawData.BrakeTemp, 4),
                    TempPneuInterna = CopyArray(rawData.TyreTempI, 4),
                    TempPneuMeio = CopyArray(rawData.TyreTempM, 4),
                    TempPneuExterna = CopyArray(rawData.TyreTempO, 4),
                    PontoContatoPneu = CopyArray(rawData.TyreContactPoint, 4),
                    NormalContatoPneu = CopyArray(rawData.TyreContactNormal, 4),
                    DirecaoContatoPneu = CopyArray(rawData.TyreContactHeading, 4),
                    VelocidadeLocal = CopyArray(rawData.LocalVelocity, 3)
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