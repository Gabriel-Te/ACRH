namespace ACRH.Repositories
{
    using ACRH.Entities;
    using System.IO.MemoryMappedFiles;
    using System.Runtime.InteropServices;
    public class AC_Repository : ITelemetryRepository
    {
        public SPageFilePhysics LerMemoriaFisica()
        {
            try
            {
                using var mmf = MemoryMappedFile.OpenExisting("acpmf_physics");
                using var accessor = mmf.CreateViewAccessor();
                
                accessor.Read(0, out SPageFilePhysics data);

                return data;

            }
            catch (FileNotFoundException)
            {
                // Jogo está fechado
                return new SPageFilePhysics();
            }
        }
    }
}
