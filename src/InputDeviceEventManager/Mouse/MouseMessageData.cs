namespace InputDeviceEventManager.Mouse
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit)]
    public class MouseMessageData
    {
        [FieldOffset(0)]
        public Point Point;

        [FieldOffset(10)]
        public short MouseData;

        [FieldOffset(16)]
        public int Timestamp;
    }
}
