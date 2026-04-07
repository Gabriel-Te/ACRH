using System.Runtime.InteropServices;

namespace ACRH.Domain.Entities
{
    public class TelemetryData
    {
        public float Acelerador { get; set; }
        public float Freio { get; set; }
        public float RPM { get; set; }
        public float Marcha { get; set; }
        public float Combustivel { get; set; }
        public float[] Pneus { get; set; } = new float[4];
    }
}
