namespace ACRH.Entities
{
        public enum AcStatus
        {
            Off = 0,
            Replay = 1,
            Live = 2,
            Pause = 3
        }

        public enum AcSessionType
        {
            Unknown = -1,
            Practice = 0,
            Qualify = 1,
            Race = 2,
            Hotlap = 3,
            TimeAttack = 4,
            Drift = 5,
            Drag = 6
        }

        public enum AcFlagType
        {
            NoFlag = 0,
            BlueFlag = 1,
            YellowFlag = 2,
            BlackFlag = 3,
            WhiteFlag = 4,
            CheckeredFlag = 5,
            PenaltyFlag = 6
        }
}
