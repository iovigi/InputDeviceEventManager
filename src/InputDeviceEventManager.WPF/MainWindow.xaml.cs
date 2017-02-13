namespace InputDeviceEventManager.WPF
{
    using System.ComponentModel;
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DeviceListener device;

        public MainWindow()
        {
            InitializeComponent();

            this.device = new DeviceListener();
            device.KeyboardKeyDown += this.Device_KeyboardKeyDown;
            device.StartListen();
        }

        private void Device_KeyboardKeyDown(object sender, Keyboard.KeyboardEventArgs keyboardEventArgs)
        {
            this.Dispatcher.Invoke(() => { this.txtBlock.Text += keyboardEventArgs.VirtualKeyCode.ToString(); });
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.device.Dispose();
            base.OnClosing(e);
        }
    }
}
