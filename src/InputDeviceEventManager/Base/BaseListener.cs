namespace InputDeviceEventManager.Base
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using Win32;

    internal abstract class BaseListener : BaseDisposableClassWithFinalizer
    {
        private readonly HookId hookId;

        private HookHandle hookHandle;

        private HookProc hookProcDelegate;

        public BaseListener(HookId hookId)
        {
            this.hookId = hookId;
        }

        public bool IsHook
        {
            get
            {
                return this.hookHandle != null && !this.hookHandle.IsClosed;
            }
        }

        public void Hook()
        {
            var source = HookNativeMethods.GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName);
            this.hookProcDelegate = new HookProc(this.OnHookCall);
            this.hookHandle = HookNativeMethods.SetWindowsHookEx((int)this.hookId, hookProcDelegate, source, 0);

            if (this.hookHandle.IsInvalid)
            {
                var errorCode = Marshal.GetLastWin32Error();
                throw new Win32Exception(errorCode);
            }
        }

        public void UnHook()
        {
            if (this.hookHandle != null)
            {
                this.hookHandle.Close();
            }

            this.hookHandle = null;
            this.hookProcDelegate = null;
        }

        private IntPtr OnHookCall(int nCode, IntPtr wParam, IntPtr lParam)
        {
            return this.HookTrigger(nCode, wParam, lParam);
        }

        protected abstract IntPtr HookTrigger(int nCode, IntPtr wParam, IntPtr lParam);

        protected override void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                this.UnHook();
            }

            base.Dispose(disposing);
        }
    }
}
