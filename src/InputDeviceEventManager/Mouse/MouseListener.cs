namespace InputDeviceEventManager.Mouse
{
    using System;
    using System.Runtime.InteropServices;
    using Base;
    using Win32;

    internal class MouseListener : BaseListener
    {
        public MouseListener()
              : base(HookId.WH_MOUSE_LL)
        {
        }

        public event MouseEventDeledate LeftButtonDown;
        public event MouseEventDeledate LeftButtonUp;
        public event MouseEventDeledate Move;
        public event MouseEventDeledate WheelRotate;
        public event MouseEventDeledate HorizontalWheelRotate;
        public event MouseEventDeledate RightButtonDown;
        public event MouseEventDeledate RightButtonUp;
        public event MouseEventDeledate Action;

        protected override IntPtr HookTrigger(int nCode, IntPtr wParam, IntPtr lParam)
        {
            var mouseMessage = (MouseMessages)wParam.ToInt32();
            MouseMessageData mouseMessageData = (MouseMessageData)Marshal.PtrToStructure(lParam, typeof(MouseMessageData));
            var eventArgs = new MouseEventArgs(mouseMessage, mouseMessageData.Point);

            switch (mouseMessage)
            {
                case MouseMessages.WM_LBUTTONDOWN:
                    this.LeftButtonDown?.Invoke(this, eventArgs);
                    break;
                case MouseMessages.WM_LBUTTONUP:
                    this.LeftButtonUp?.Invoke(this, eventArgs);
                    break;
                case MouseMessages.WM_MOUSEMOVE:
                    this.Move?.Invoke(this, eventArgs);
                    break;
                case MouseMessages.WM_MOUSEWHEEL:
                    this.WheelRotate?.Invoke(this, eventArgs);
                    break;
                case MouseMessages.WM_MOUSEHWHEEL:
                    this.HorizontalWheelRotate?.Invoke(this, eventArgs);
                    break;
                case MouseMessages.WM_RBUTTONDOWN:
                    this.RightButtonDown?.Invoke(this, eventArgs);
                    break;
                case MouseMessages.WM_RBUTTONUP:
                    this.RightButtonUp?.Invoke(this, eventArgs);
                    break;
            }

            this.Action?.Invoke(this, eventArgs);

            return HookNativeMethods.CallNextHookEx((int)HookId.WH_MOUSE_LL, nCode, wParam, lParam);
        }
    }
}
