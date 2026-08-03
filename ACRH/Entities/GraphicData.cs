using ACRH.Entities;

namespace ACRH.Entities
{
    public class GraphicData
    {
        // --- Imagem 1: Informações Básicas e Tempos ---
        public int IdPacote { get; set; }
        public AcStatus Status { get; set; }
        public AcSessionType TipoSessao { get; set; }

        public char[] BufferCurrentTime = new char[15];
        public char[] BufferLastTime = new char[15];
        public char[] BufferBestTime = new char[15];
        public char[] BufferSplit= new char[15];

        public int CompletedLaps { get; set; }

        // --- Imagem 2: Posicionamento, Tempos (MS) e Pista ---
        public int Position { get; set; }
        public int ICurrentTime { get; set; }
        public int ILastTime { get; set; }
        public int IBestTime { get; set; }

        public float SessionTimeLeft { get; set; }
        public float DistanceTraveled { get; set; }

        public int IsInPit { get; set; }
        public int CurrentSectorIndex { get; set; }
        public int LastSectorTime { get; set; }
        public int NumberOfLaps { get; set; }

        public char[] BufferTyreCompound = new char[33];

        public float ReplayTimeMultiplier { get; set; }
        public float NormalizedCarPosition { get; set; }

        public float[] CarCoordinates { get; set; } = new float[3];

        public float PenaltyTime { get; set; }
        public AcFlagType Flag { get; set; }

        public int IdealLineOn { get; set; }
        public int IsInPitLane { get; set; }
        public float SurfaceGrip { get; set; }
        public int MandatoryPitDone { get; set; }

        public float WindSpeed { get; set; }
        public float WindDirection { get; set; }
    }
}