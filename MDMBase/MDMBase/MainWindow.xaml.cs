using MDMBase.ViewModel.MainView;
using System.IO;
using System.Windows;

namespace MDMBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NotifyIcon? notifyIcon;

        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel; // ViewModel을 DataContext에 설정

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

        protected override void OnStateChanged(EventArgs e)
        {
            base.OnStateChanged(e);

            if(WindowState == WindowState.Minimized)
            {
                this.Hide();

                // 트레이 아이콘을 업데이트하여 알림 표시 시 문제 해결
                //notifyIcon!.Icon = SystemIcons.Info; // 임시 아이콘 설정
                notifyIcon!.Icon = new Icon(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Images\run_ico.ico")); // 원래 아이콘 복구

                notifyIcon!.BalloonTipTitle = "프로그램 알림";
                notifyIcon!.BalloonTipText = "MDM 프로그램이 백그라운드에서 동작중입니다.";
                notifyIcon!.ShowBalloonTip(100);
            }
        }

        private void MainAppWindow_StateChanged(object sender, EventArgs e)
        {
            if(WindowState == WindowState.Minimized)
            {
                this.Hide(); // 창 숨기기 (트레이 아이콘만 남김)
            }
        }

        private void MainAppWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            notifyIcon!.Dispose(); // 리소스 정리
            System.Windows.Application.Current.Shutdown();
        }


    }
}