using System.Runtime.InteropServices;

namespace ACRH.Domain.Entities
{
    public class TelemetryData
    {
        public float Acelerador { get; set; }
        public float Freio { get; set; }
        public int RPM { get; set; }
        public int Marcha { get; set; }
        public int Combustivel { get; set; }
        public float[] Pneus { get; set; } = new float[4];
    }
}
