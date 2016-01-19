using System;
using System.Runtime.InteropServices;

namespace PowerStateManagement
{
    public class PowerManager
    {
        const uint STATUS_SUCCESS = 0;

        [DllImport("powrprof.dll", SetLastError = true)]
        private static extern UInt32 CallNtPowerInformation(
            int informationLevel,
            IntPtr lpInputBuffer,
            int nInputBufferSize,
            out SYSTEM_POWER_INFORMATION outpuBuffer,
            int nOutputBufferSize);

        [DllImport("powrprof.dll", SetLastError = true)]
        private static extern UInt32 CallNtPowerInformation(
            int informationLevel,
            IntPtr lpInputBuffer,
            int nInputBufferSize,
            out SYSTEM_BATTERY_STATE outpuBuffer,
            int nOutputBufferSize);

        [DllImport("powrprof.dll", SetLastError = true)]
        private static extern UInt32 CallNtPowerInformation(
            int informationLevel,
            IntPtr lpInputBuffer,
            int nInputBufferSize,
            out LAST_SLEEP_TIME outpuBuffer,
            int nOutputBufferSize);

        [DllImport("powrprof.dll", SetLastError = true)]
        private static extern UInt32 CallNtPowerInformation(
            int informationLevel,
            IntPtr lpInputBuffer,
            int nInputBufferSize,
            out LAST_WAKE_TIME outpuBuffer,
            int nOutputBufferSize);

        public LAST_SLEEP_TIME CallLastSleepTimeInfo()
        {
            var lastSleepTimeInfo = new LAST_SLEEP_TIME();
            uint retval = CallNtPowerInformation(
                (int)PowerInformationLevel.LastSleepTime,
                IntPtr.Zero,
                0,
                out lastSleepTimeInfo,
                Marshal.SizeOf(typeof(LAST_SLEEP_TIME)));

            if (retval == STATUS_SUCCESS)
            {
                return lastSleepTimeInfo;
            }

            return new LAST_SLEEP_TIME();
        }

        public LAST_WAKE_TIME CallLastWakeTimeInfo()
        {
            var lastSleepTimeInfo = new LAST_WAKE_TIME();
            uint retval = CallNtPowerInformation(
                (int)PowerInformationLevel.LastWakeTime,
                IntPtr.Zero,
                0,
                out lastSleepTimeInfo,
                Marshal.SizeOf(typeof(LAST_WAKE_TIME)));

            if (retval == STATUS_SUCCESS)
            {
                return lastSleepTimeInfo;
            }

            return new LAST_WAKE_TIME();
        }

        public SYSTEM_POWER_INFORMATION CallSystemPowerInfo()
        {
            var lastSleepTimeInfo = new SYSTEM_POWER_INFORMATION();
            uint retval = CallNtPowerInformation(
                (int)PowerInformationLevel.SystemPowerInformation,
                IntPtr.Zero,
                0,
                out lastSleepTimeInfo,
                Marshal.SizeOf(typeof(SYSTEM_POWER_INFORMATION)));

            if (retval == STATUS_SUCCESS)
            {
                return lastSleepTimeInfo;
            }

            return new SYSTEM_POWER_INFORMATION();
        }

        public SYSTEM_BATTERY_STATE CallSystemBatteryState()
        {
            var lastSleepTimeInfo = new SYSTEM_BATTERY_STATE();
            uint retval = CallNtPowerInformation(
                (int)PowerInformationLevel.SystemBatteryState,
                IntPtr.Zero,
                0,
                out lastSleepTimeInfo,
                Marshal.SizeOf(typeof(SYSTEM_BATTERY_STATE)));

            if (retval == STATUS_SUCCESS)
            {
                return lastSleepTimeInfo;
            }

            return new SYSTEM_BATTERY_STATE();
        }
    }
}