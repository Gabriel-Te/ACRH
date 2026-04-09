using System.Runtime.InteropServices;

namespace ACRH.Entities
{
    public class TelemetryData
    {
        public float Acelerador { get; set; }
        public float Freio { get; set; }
        public int RPM { get; set; }
        public int Marcha { get; set; }
        public float Combustivel { get; set; }
        public float[] PneusTMP { get; set; } = new float[4];
    }
}
