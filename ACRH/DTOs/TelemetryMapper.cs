using ACRH.Entities;

namespace ACRH.DTOs
{
    public static class TelemetryMapper
    {

        public static unsafe void UpdatePhysics(this SPageFilePhysics raw, PhysicsData globalDto)
        {
            // === Dados Básicos ===
            globalDto.Acelerador = raw.Gas;
            globalDto.Freio = raw.Brake;
            globalDto.Marcha = raw.Gear;
            globalDto.IdPacote = raw.PacketId;
            globalDto.Combustivel = raw.Fuel;
            globalDto.Rpm = raw.Rpms;
            globalDto.AnguloEsterco = raw.SteerAngle;
            globalDto.VelocidadeKmh = raw.SpeedKmh;

            // === Sistemas e Auxílios ===
            globalDto.Drs = raw.Drs;
            globalDto.ControleTracao = raw.TC;
            globalDto.Rumo = raw.Heading;
            globalDto.Arfagem = raw.Pitch;
            globalDto.Rolagem = raw.Roll;
            globalDto.AlturaCentroGravidade = raw.CGHeight;

            globalDto.QtdPneusForaPista = raw.NumberOfTyresOut;
            globalDto.LimitadorPitStopLigado = raw.PitLimiterOn;
            globalDto.Abs = raw.Abs;
            globalDto.CargaKers = raw.KersCharge;
            globalDto.EntradaKers = raw.KersInput;
            globalDto.CambioAutomaticoLigado = raw.AutoShifterOn;

            // === Ambiente e Motor ===
            globalDto.Turbo = raw.TurboBoost;
            globalDto.Lastro = raw.Ballast;
            globalDto.DensidadeAr = raw.AirDensity;
            globalDto.TemperaturaAr = raw.AirTemp;
            globalDto.TemperaturaPista = raw.RoadTemp;
            globalDto.FeedbackForcaFinal = raw.FinalFFB;
            globalDto.MedidorPerformance = raw.PerformanceMeter;
            globalDto.FreioMotor = raw.EngineBrake;
            globalDto.NivelRecuperacaoErs = raw.ErsRecoveryLevel;
            globalDto.NivelPotenciaErs = raw.ErsPowerLevel;
            globalDto.CarregamentoCalorErs = raw.ErsHeatCharging;
            globalDto.ErsEstaCarregando = raw.ErsisCharging;
            globalDto.KersAtualKJ = raw.KersCurrentKJ;
            globalDto.DrsDisponivel = raw.DrasAvailable;
            globalDto.DrsAtivado = raw.DrsEnabled;
            globalDto.Embreagem = raw.Clutch;
            globalDto.ControladoPelaIA = raw.IsAIControlled;
            globalDto.BalancoFreio = raw.BrakeBias;

            // === Vetores e Arrays (Zero Allocation) ===
            UpdateArray(raw.Velocity, globalDto.VelocidadeVetor, 3);
            UpdateArray(raw.AccG, globalDto.ForcaG, 3);
            UpdateArray(raw.WheelSlip, globalDto.DeslizeRoda, 4);
            UpdateArray(raw.WheelLoad, globalDto.CargaRoda, 4);
            UpdateArray(raw.WheelsPressure, globalDto.PressaoPneus, 4);
            UpdateArray(raw.WheelAngularSpeed, globalDto.VelocidadeAngularRoda, 4);
            UpdateArray(raw.TyreWear, globalDto.DesgastePneu, 4);
            UpdateArray(raw.TyreDirtyLevel, globalDto.NivelSujeiraPneu, 4);
            UpdateArray(raw.TyreCoreTemp, globalDto.TempNucleoPneu, 4);
            UpdateArray(raw.CamberRAD, globalDto.CambagemRad, 4);
            UpdateArray(raw.SuspensionTravel, globalDto.CursoSuspensao, 4);
            UpdateArray(raw.CarDamage, globalDto.DanoCarro, 5);
            UpdateArray(raw.RideHeight, globalDto.AlturaSolo, 2);
            UpdateArray(raw.LocalAngularVel, globalDto.VelocidadeAngularLocal, 3);
            UpdateArray(raw.BrakeTemp, globalDto.TempFreio, 4);
            UpdateArray(raw.TyreTempI, globalDto.TempPneuInterna, 4);
            UpdateArray(raw.TyreTempM, globalDto.TempPneuMeio, 4);
            UpdateArray(raw.TyreTempO, globalDto.TempPneuExterna, 4);
            UpdateArray(raw.TyreContactPoint, globalDto.PontoContatoPneu, 4);
            UpdateArray(raw.TyreContactNormal, globalDto.NormalContatoPneu, 4);
            UpdateArray(raw.TyreContactHeading, globalDto.DirecaoContatoPneu, 4);
            UpdateArray(raw.LocalVelocity, globalDto.VelocidadeLocal, 3);
        }

        // === Método Helper para atualizar arrays sem usar 'new' ===
        private static unsafe void UpdateArray(float* source, float[] destination, int length)
        {
            for (int i = 0; i < length; i++)
            {
                destination[i] = source[i];
                
            }
        }


        public static unsafe void UpdateStatic(this SPageFileStatic raw, StaticData globalDto)
        {
            // === Informações Básicas e Jogador (Strings) ===
            // Nota: O C# precisa alocar memória para criar strings a partir de ponteiros de char.
            CopyChars(raw.SmVersion, globalDto.VersaoMemoriaCompartilhada, 15);
            CopyChars(raw.AcVersion, globalDto.VersaoAssettoCorsa, 15);
            CopyChars(raw.CarModel, globalDto.ModeloCarro, 33);
            CopyChars(raw.Track, globalDto.Pista, 33);
            CopyChars(raw.PlayerName, globalDto.NomeJogador, 33);
            CopyChars(raw.PlayerSurname, globalDto.SobrenomeJogador, 33);
            CopyChars(raw.PlayerNick, globalDto.ApelidoJogador, 33);
            CopyChars(raw.TrackConfiguration, globalDto.ConfiguracaoPista, 33);
            CopyChars(raw.CarSkin, globalDto.SkinCarro, 33);

            // === Inteiros e Floats ===
            globalDto.NumeroSessoes = raw.NumberOfSessions;
            globalDto.NumeroCarros = raw.NumCars;
            globalDto.QuantidadeSetores = raw.SectorCount;

            globalDto.TorqueMaximo = raw.MaxTorque;
            globalDto.PotenciaMaxima = raw.MaxPower;
            globalDto.RpmMaximo = raw.MaxRpm;
            globalDto.CombustivelMaximo = raw.MaxFuel;
            globalDto.PressaoMaximaTurbo = raw.MaxTurboBoost;
            globalDto.QtdConfiguracoesFreioMotor = raw.EngineBrakeSettingsCount;

            globalDto.EnergiaMaximaKersJ = raw.KersMaxJ;
            globalDto.EnergiaMaximaErsJ = raw.ErsMaxJ;
            globalDto.PossuiDRS = raw.HasDRS;
            globalDto.PossuiERS = raw.HasERS;
            globalDto.PossuiKERS = raw.HasKERS;
            globalDto.QtdControladoresPotenciaErs = raw.ErsPowerControllerCount;

            globalDto.PenalidadesAtivadas = raw.PenaltiesEnabled;
            globalDto.TaxaConsumoCombustivel = raw.AidFuelRate;
            globalDto.TaxaDesgastePneus = raw.AidTireRate;
            globalDto.TaxaDanoMecanico = raw.AidMechanicalDamage;
            globalDto.CobertoresPneuPermitidos = raw.AidAllowTyreBlankets;
            globalDto.AuxilioEstabilidade = raw.AidStability;
            globalDto.EmbreagemAutomatica = raw.AidAutoClutch;
            globalDto.PontaTacoAutomatico = raw.AidAutoBlip;

            globalDto.ComprimentoPista = raw.TrackSplineLength;
            globalDto.CorridaPorTempo = raw.IsTimedRace;
            globalDto.PossuiVoltaExtra = raw.HasExtraLap;
            globalDto.PosicoesGridInvertido = raw.ReversedGridPositions;
            globalDto.InicioJanelaPit = raw.PitWindowStart;
            globalDto.FimJanelaPit = raw.PitWindowEnd;

            // === Vetores e Arrays (Zero Allocation) ===
            UpdateArray(raw.SuspensionMaxTravel, globalDto.CursoMaximoSuspensao, 4);
            UpdateArray(raw.TyreRadius, globalDto.RaioPneu, 4);
        }

        public static unsafe void UpdateGraphic(SPageFileGraphic raw, GraphicData globalDto)
        {
            // --- Imagem 1 ---
            globalDto.IdPacote = raw.PacketId;
            globalDto.Status = (AcStatus)raw.Status;
            globalDto.TipoSessao = (AcSessionType)raw.Session;



            CopyChars(raw.CurrentTime, globalDto.BufferCurrentTime, 15);
            CopyChars(raw.LastTime, globalDto.BufferLastTime, 15);
            CopyChars(raw.BestTime, globalDto.BufferBestTime, 15);
            CopyChars(raw.Split, globalDto.BufferSplit, 15);


            globalDto.CompletedLaps = raw.CompletedLaps;

            // --- Imagem 2 ---
            globalDto.Position = raw.Position;
            globalDto.ICurrentTime = raw.ICurrentTime;
            globalDto.ILastTime = raw.ILastTime;
            globalDto.IBestTime = raw.IBestTime;

            globalDto.SessionTimeLeft = raw.SessionTimeLeft;
            globalDto.DistanceTraveled = raw.DistanceTraveled;

            globalDto.IsInPit = raw.IsInPit;
            globalDto.CurrentSectorIndex = raw.CurrentSectorIndex;
            globalDto.LastSectorTime = raw.LastSectorTime;
            globalDto.NumberOfLaps = raw.NumberOfLaps;

            CopyChars(raw.TyreCompound, globalDto.BufferTyreCompound, 33);

            globalDto.ReplayTimeMultiplier = raw.ReplayTimeMultiplier;
            globalDto.NormalizedCarPosition = raw.NormalizedCarPosition;

            globalDto.CarCoordinates[0] = raw.CarCoordinates[0];
            globalDto.CarCoordinates[1] = raw.CarCoordinates[1];
            globalDto.CarCoordinates[2] = raw.CarCoordinates[2];

            globalDto.PenaltyTime = raw.PenaltyTime;
            globalDto.Flag = (AcFlagType)raw.Flag;

            globalDto.IdealLineOn = raw.IdealLineOn;
            globalDto.IsInPitLane = raw.IsInPitLane;
            globalDto.SurfaceGrip = raw.SurfaceGrip;
            globalDto.MandatoryPitDone = raw.MandatoryPitDone;

            globalDto.WindSpeed = raw.WindSpeed;
            globalDto.WindDirection = raw.WindDirection;
        }

        private static unsafe void CopyChars(char* src, char[] dest, int length)
        {
            for (int i = 0; i < length; i++)
            {
                dest[i] = src[i];
            }
        }
    }
}
