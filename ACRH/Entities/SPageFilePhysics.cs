using System.Runtime.InteropServices;

namespace ACRH.Entities
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public unsafe struct SPageFilePhysics
    {
        public int PacketId;
        public float Gas;
        public float Brake;
        public float Fuel;
        public int Gear;
        public int Rpms;
        public float SteerAngle;
        public float SpeedKmh;

        public fixed float Velocity[3];
        public fixed float AccG[3];
        public fixed float WheelSlip[4];
        public fixed float WheelLoad[4];
        public fixed float WheelsPressure[4];
        public fixed float WheelAngularSpeed[4];
        public fixed float TyreWear[4];
        public fixed float TyreDirtyLevel[4];
        public fixed float TyreCoreTemp[4];
        public fixed float CamberRAD[4];
        public fixed float SuspensionTravel[4];

        public float Drs;
        public float TC;
        public float Heading;
        public float Pitch;
        public float Roll;
        public float CGHeight;

        public fixed float CarDamage[5];

        public int NumberOfTyresOut;
        public int PitLimiterOn;
        public float Abs;
        public float KersCharge;
        public float KersInput;
        public int AutoShifterOn;

        public fixed float RideHeight[2];

        public float TurboBoost;
        public float Ballast;
        public float AirDensity;
        public float AirTemp;
        public float RoadTemp;

        public fixed float LocalAngularVel[3];

        public float FinalFFB;
        public float PerformanceMeter;
        public int EngineBrake;
        public int ErsRecoveryLevel;
        public int ErsPowerLevel;
        public int ErsHeatCharging;
        public int ErsisCharging;
        public float KersCurrentKJ;
        public int DrasAvailable;
        public int DrsEnabled;

        public fixed float BrakeTemp[4];

        public float Clutch;

        public fixed float TyreTempI[4];
        public fixed float TyreTempM[4];
        public fixed float TyreTempO[4];

        public int IsAIControlled;

        public fixed float TyreContactPoint[4];
        public fixed float TyreContactNormal[4];
        public fixed float TyreContactHeading[4];

        public float BrakeBias;

        public fixed float LocalVelocity[3];
    }
}