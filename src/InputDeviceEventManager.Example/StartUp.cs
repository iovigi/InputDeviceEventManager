namespace InputDeviceEventManager.Example
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using InputDeviceEventManager;
    using System.Windows;


    public class StartUp
    {
        public static void Main(string[] args)
        {
            Thread thread = new Thread(Module);
            thread.Start();


            while (true)
            {

                Console.ReadLine();
            }
        }

        private static void Module()
        {
            DeviceListener deviceListener = new DeviceListener();
            deviceListener.StartListen();

            while (true)
            {
                Console.ReadLine();
            }
        }
    }
}
