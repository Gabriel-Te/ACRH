using ACRH.Entities;

public unsafe interface ITelemetryRepository
{
    SPageFileStatic* GetStatic();
    SPageFilePhysics* GetPhysics();
    SPageFileGraphic* GetGraphic();
}
