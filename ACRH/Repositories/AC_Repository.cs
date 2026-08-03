using System.IO.MemoryMappedFiles;
using ACRH.Entities;

namespace ACRH.Repositories
{
    public unsafe class AC_Repository : ITelemetryRepository, IDisposable
    {   
        
        // Variáveis para manter as conexões (handles) abertas
        private MemoryMappedFile _mmfStatic;
        private MemoryMappedFile _mmfPhysics;
        private MemoryMappedFile _mmfGraphic;

        private MemoryMappedViewAccessor _accStatic;
        private MemoryMappedViewAccessor _accPhysics;
        private MemoryMappedViewAccessor _accGraphic;

        // Ponteiros brutos que guardam os endereços de memória
        private byte* _ptrStatic;
        private byte* _ptrPhysics;
        private byte* _ptrGraphic;
        public bool IsConnected => _mmfStatic != null; // Adicione isso

        public AC_Repository()
        {
            try {
                // Abre os mapeamentos de memória (o jogo deve estar aberto)
                // Use o prefixo "Local\" antes do nome
                _mmfStatic = MemoryMappedFile.OpenExisting("Local\\acpmf_static");
                _mmfPhysics = MemoryMappedFile.OpenExisting("Local\\acpmf_physics");
                _mmfGraphic = MemoryMappedFile.OpenExisting("Local\\acpmf_graphics");



                // Cria os Accessors (janelas de leitura)
                _accStatic = _mmfStatic.CreateViewAccessor();
                _accPhysics = _mmfPhysics.CreateViewAccessor();
                _accGraphic = _mmfGraphic.CreateViewAccessor();

                // Adquire os ponteiros (o "segredo" da performance)
                _accStatic.SafeMemoryMappedViewHandle.AcquirePointer(ref _ptrStatic);
                _accPhysics.SafeMemoryMappedViewHandle.AcquirePointer(ref _ptrPhysics);
                _accGraphic.SafeMemoryMappedViewHandle.AcquirePointer(ref _ptrGraphic);
            }
            catch (FileNotFoundException)
            {
                // O jogo não está aberto. 
                // Aqui você pode logar um erro ou definir uma flag indicando que não há telemetria disponível.
                Console.WriteLine("Assetto Corsa não encontrado. Telemetria indisponível.");
            }
        }

        // Métodos que retornam apenas o ponteiro tipado.
        // O Worker que chame esses métodos receberá o ponteiro 
        // e poderá acessar os campos usando o operador '->'
        public SPageFileStatic* GetStatic() => _ptrStatic != null ? (SPageFileStatic*)_ptrStatic : null;
        public SPageFilePhysics* GetPhysics() => _ptrPhysics != null ? (SPageFilePhysics*)_ptrPhysics : null;
        public SPageFileGraphic* GetGraphic() => _ptrGraphic != null ? (SPageFileGraphic*)_ptrGraphic : null;

        // Implementação do IDisposable para liberar a memória corretamente
        public void Dispose()
        {
            _accStatic?.SafeMemoryMappedViewHandle.ReleasePointer();
            _accPhysics?.SafeMemoryMappedViewHandle.ReleasePointer();
            _accGraphic?.SafeMemoryMappedViewHandle.ReleasePointer();

            _accStatic?.Dispose();
            _accPhysics?.Dispose();
            _accGraphic?.Dispose();

            _mmfStatic?.Dispose();
            _mmfPhysics?.Dispose();
            _mmfGraphic?.Dispose();
        }
    }
}