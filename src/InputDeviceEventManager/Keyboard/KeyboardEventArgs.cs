namespace InputDeviceEventManager.Keyboard
{
    public class KeyboardEventArgs
    {
        public KeyboardEventArgs(KeyboardMessages keyboardMessage, VirtualKeyCodes virtualKeyCode)
        {
            this.KeyboardMessage = keyboardMessage;
            this.VirtualKeyCode = virtualKeyCode;
        }

        public KeyboardMessages KeyboardMessage { get; private set; }
        public VirtualKeyCodes VirtualKeyCode { get; private set; }
    }
}
