namespace InputDeviceEventManager.Keyboard
{
    using System.Runtime.InteropServices;

    [StructLayout(layoutKind : LayoutKind.Explicit, CharSet = CharSet.Auto)]
    public class KeyboardMessageData
    {
        [FieldOffset(0)]
        public VirtualKeyCodes VkCode;
        [FieldOffset(4)]
        public int ScanCode;
        [FieldOffset(8)]
        public int Flags;
        [FieldOffset(12)]
        public int Time;
        [FieldOffset(16)]
        public int DwExtraInfo;
    }
}
