using ACRH.Domain.Entities;
using ACRH.Repositories;

namespace ACRH.Services
{
    public unsafe class TelemetryService : ITelemetryService
    {
        public TelemetryData ExibirTelemetria()
        {
            try
            {
                AC_Repository acr = new AC_Repository();
                SPageFilePhysics rawData = acr.LerMemoriaFisica();
                return new TelemetryData()
                {
                    Acelerador = rawData.Gas,
                    Freio = rawData.Brake,
                    RPM = rawData.Rpms,
                    Marcha = rawData.Gear - 1,
                    Combustivel = rawData.Fuel,
                    Pneus = [
                    rawData.TyreTemp[0],
                    rawData.TyreTemp[1],
                    rawData.TyreTemp[2],
                    rawData.TyreTemp[3]
                    ]
                };
            }
            catch (Exception)
            {
                return new TelemetryData();
            }
        }
    }
}
