using System.Runtime.InteropServices;

namespace ACRH.Entities
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public unsafe struct SPageFileStatic
    {
        // --- Imagem 1: Configurações Básicas e Sessão ---
        public fixed char SmVersion[15]; // wchar_t smVersion[15]
        public fixed char AcVersion[15]; // wchar_t acVersion[15]
        public int NumberOfSessions;
        public int NumCars;
        public fixed char CarModel[33];   // wchar_t carModel[33]
        public fixed char Track[33];      // wchar_t track[33]
        public fixed char PlayerName[33]; // wchar_t playerName[33]
        public fixed char PlayerSurname[33]; // wchar_t playerSurname[33]
        public fixed char PlayerNick[33];    // wchar_t playerNick[33]
        public int SectorCount;

        // --- Dados de Performance Estimados do Carro ---
        public float MaxTorque;
        public float MaxPower;
        public int MaxRpm;
        public float MaxFuel;
        public fixed float SuspensionMaxTravel[4];
        public fixed float TyreRadius[4];
        public float MaxTurboBoost;

        // Campos legados mantidos para não quebrar o alinhamento de bytes
        public float Deprecated_1;
        public float Deprecated_2;

        // --- Regras e Assistências ---
        public int PenaltiesEnabled;
        public float AidFuelRate;

        // --- Imagem 2: Assistências Adicionais e Infos da Pista ---
        public float AidTireRate;
        public float AidMechanicalDamage;
        public int AidAllowTyreBlankets;
        public float AidStability;
        public int AidAutoClutch;
        public int AidAutoBlip;

        // --- Disponibilidade de Sistemas Especiais ---
        public int HasDRS;
        public int HasERS;
        public int HasKERS;
        public float KersMaxJ;
        public int EngineBrakeSettingsCount;
        public int ErsPowerControllerCount;

        // --- Dados da Pista e Corrida ---
        public float TrackSplineLength;
        public fixed char TrackConfiguration[33]; // wchar_t trackConfiguration[33]
        public float ErsMaxJ;
        public int IsTimedRace;
        public int HasExtraLap;
        public fixed char CarSkin[33]; // wchar_t carSkin[33]
        public int ReversedGridPositions;
        public int PitWindowStart;
        public int PitWindowEnd;
    }
}