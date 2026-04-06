using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public unsafe struct SPageFilePhysics
{
    public int PacketId;
    public float Gas;
    public float Brake;
    public float Fuel;
    public float Gear;
    public float Rpms;
    public float SteerAngle;
    public float SpeedKmh;
    public fixed float WheelAngularSpeed[4];
    public fixed float TyreWear[4];
    public fixed float TyreTemp[4];
}