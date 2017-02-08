namespace InputDeviceEventManager.Mouse
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit)]
    public class MouseMessageData
    {
        [FieldOffset(0x00)]
        public Point Point;

        [FieldOffset(0x0A)]
        public short MouseData;

        [FieldOffset(0x10)]
        public int Timestamp;
    }
}
