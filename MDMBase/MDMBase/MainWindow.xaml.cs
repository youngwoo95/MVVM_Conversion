using MDMBase.ViewModel.MainView;
using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace MDMBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel;
        private NotifyIcon? notifyIcon;

        public MainWindow()
        {
            InitializeComponent();
            InitializeTrayIcon();
        }

        private void InitializeTrayIcon()
        {
            notifyIcon = new NotifyIcon
            {
                Icon = new Icon(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Images\run_ico.ico")),
                Visible = true,
                Text = "MDMSender_V02"
            };

            notifyIcon.ContextMenuStrip = new ContextMenuStrip();
            notifyIcon.ContextMenuStrip.Items.Add("Open", null, OpenApp_Click);
            notifyIcon.ContextMenuStrip.Items.Add("Exit", null, ExitApp_Click);

            notifyIcon.DoubleClick += OpenApp_Click;
        }

        // 델리게이트 이벤트 동작
        private void OpenApp_Click(object? sender, EventArgs e)
        {
            this.Show();
            this.WindowState = WindowState.Normal;
            this.Activate(); // 창에 포커스 설정
        }

        private void ExitApp_Click(object? sender, EventArgs e)
        {
            notifyIcon!.Dispose();
            System.Windows.Application.Current.Shutdown();
        }

    }
}