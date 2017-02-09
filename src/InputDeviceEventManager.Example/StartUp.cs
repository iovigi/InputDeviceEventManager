namespace InputDeviceEventManager.Example
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using InputDeviceEventManager;
    using Keyboard;
    using Mouse;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            DeviceListener deviceListener = new DeviceListener();
            deviceListener.StartListen();
            deviceListener.MouseAction += OnMouseAction;
            deviceListener.KeyboardAction += OnKeyboardAction;

            Console.ReadLine();
            deviceListener.StopListen();
        }

        private static void OnKeyboardAction(object sender, KeyboardEventArgs keyboardEventArgs)
        {
            Console.WriteLine(keyboardEventArgs.VirtualKeyCode);
        }

        private static void OnMouseAction(object sender, Mouse.MouseEventArgs mouseEventArgs)
        {
            Console.WriteLine(mouseEventArgs.Point.X);
        }
    }
}
