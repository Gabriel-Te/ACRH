using System.Runtime.InteropServices;

namespace ACRH.Entities
{
    // --- Enums Auxiliares do Assetto Corsa para ajudar no mapeamento ---
    public enum AcStatus
    {
        Off = 0,
        Replay = 1,
        Live = 2,
        Pause = 3
    }

    public enum AcSessionType
    {
        Unknown = -1,
        Practice = 0,
        Qualify = 1,
        Race = 2,
        Hotlap = 3,
        TimeAttack = 4,
        Drift = 5,
        Drag = 6
    }

    public enum AcFlagType
    {
        NoFlag = 0,
        BlueFlag = 1,
        YellowFlag = 2,
        BlackFlag = 3,
        WhiteFlag = 4,
        CheckeredFlag = 5,
        PenaltyFlag = 6
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public unsafe struct SPageFileGraphic
    {
        // --- Imagem 1: Informações Básicas da Sessão e Tempos ---
        public int PacketId;
        public int Status;             // Equivalente ao enum AcStatus (int)
        public int Session;            // Equivalente ao enum AcSessionType (int)

        // Tempos em formato de texto (wchar_t[15])
        public fixed char CurrentTime[15 * 2];
        public fixed char LastTime[15 * 2];
        public fixed char BestTime[15 * 2];
        public fixed char Split[15 * 2];

        public int CompletedLaps;

        // --- Imagem 2: Posicionamento, Tempos (MS) e Pista ---
        public int Position;
        public int ICurrentTime;       // Tempo da volta atual em milissegundos
        public int ILastTime;          // Tempo da última volta em milissegundos
        public int IBestTime;          // Melhor tempo de volta em milissegundos

        public float SessionTimeLeft;
        public float DistanceTraveled;

        public int IsInPit;
        public int CurrentSectorIndex;
        public int LastSectorTime;
        public int NumberOfLaps;

        // Composto de pneu atual (ex: "S" para soft, "M" para medium)
        public fixed char TyreCompound[33 * 2]; // wchar_t tyreCompound[33]

        public float ReplayTimeMultiplier;
        public float NormalizedCarPosition;

        // Coordenadas globais do carro no mundo [x, y, z]
        public fixed float CarCoordinates[3];

        public float PenaltyTime;
        public int Flag;               // Equivalente ao enum AcFlagType (int)

        public int IdealLineOn;
        public int IsInPitLane;
        public float SurfaceGrip;
        public int MandatoryPitDone;

        public float WindSpeed;
        public float WindDirection;    // Direção do vento de 0 a 359 graus
    }
}