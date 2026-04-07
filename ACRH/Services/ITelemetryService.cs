using ACRH.Domain.Entities;
using ACRH.Repositories;

namespace ACRH.Services
{
    public interface ITelemetryService
    {
        public TelemetryData ExibirTelemetria(); 
    }
}
