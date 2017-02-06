namespace InputDeviceEventManager.Keyboard
{
    using Base;
    using Win32;

    internal class KeyboardListener : BaseListener
    {
        public KeyboardListener()
            :base(HookId.WH_KEYBOARD_LL)
        {
        }
    }
}
