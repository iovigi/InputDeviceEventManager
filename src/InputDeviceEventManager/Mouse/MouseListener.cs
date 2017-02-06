namespace InputDeviceEventManager.Mouse
{
    using Base;
    using Win32;

    internal class MouseListener : BaseListener
    {
        public MouseListener()
              : base(HookId.WH_MOUSE_LL)
        {
        }
    }
}
