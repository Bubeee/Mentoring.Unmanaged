using System;
using System.Runtime.InteropServices;

namespace PowerStateManagement
{
    public class PowerManager
    {
        const int SystemPowerInformation = 12;
        const uint STATUS_SUCCESS = 0;

        public struct SYSTEM_POWER_INFORMATION
        {
            public uint MaxIdlenessAllowed;
            public uint Idleness;
            public uint TimeRemaining;
            public byte CoolingMode;
        }

        [DllImport("powrprof.dll", SetLastError = true)]
        private static extern UInt32 CallNtPowerInformation(
            int informationLevel,
            IntPtr lpInputBuffer,
            int nInputBufferSize,
            out SYSTEM_POWER_INFORMATION spi,
            int nOutputBufferSize);

        public SYSTEM_POWER_INFORMATION CallPowerInfo()
        {
            SYSTEM_POWER_INFORMATION spi;
            uint retval = CallNtPowerInformation(
                SystemPowerInformation,
                IntPtr.Zero,
                0,
                out spi,
                Marshal.SizeOf(typeof(SYSTEM_POWER_INFORMATION))
            );

            if (retval == STATUS_SUCCESS)
                return spi;

            return new SYSTEM_POWER_INFORMATION();
        }
    }
}