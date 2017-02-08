namespace InputDeviceEventManager.Example
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using InputDeviceEventManager;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            DeviceListener deviceListener = new DeviceListener(true);
            deviceListener.StartListen();
            deviceListener.StopListen();
        }
    }
}
