namespace PowerStateManagement
{
    public struct SYSTEM_POWER_INFORMATION
    {
        public uint MaxIdlenessAllowed;
        public uint Idleness;
        public uint TimeRemaining;
        public byte CoolingMode;
    }

    public struct SYSTEM_BATTERY_STATE
    {
        public bool AcOnLine;
        public bool BatteryPresent;
        public bool Charging;
        public bool Discharging;
        public int Spare1;
        public int MaxCapacity;
        public int RemainingCapacity;
        public int Rate;
        public int EstimatedTime;
        public int DefaultAlert1;
        public int DefaultAlert2;
    }

    public struct LAST_WAKE_TIME
    {
        public uint LastWakeTime { get; set; }
    }

    public struct LAST_SLEEP_TIME
    {
        public uint LastSleepTime { get; set; }
    }
}