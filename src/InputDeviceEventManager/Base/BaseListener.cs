namespace InputDeviceEventManager.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Win32;

    internal class BaseListener : BaseDisposableClassWithFinalizer
    {
        private readonly HookId hooId;

        public BaseListener(HookId hookId)
        {

        }


    }
}
