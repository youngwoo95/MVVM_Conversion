using System.IO;
using System.Windows;

namespace MDMBase.ViewModel.MainView
{
    public partial class MainViewModel
	{
		private NotifyIcon? notifyIcon;

		// 델리게이트 정의
		public Action? OnMinimizeRequested;

		/// <summary>
		/// LOAD 이벤트
		/// </summary>
		/// <param name="parameter"></param>
		private void OnLoaded(object parameter)
		{
			Console.WriteLine("실행");

			/* 트레이설정 */
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

        }

        // 델리게이트 이벤트 동작
        private void OpenApp_Click(object? sender, EventArgs e)
		{
			var temp = new MainWindow();
			temp.Show();
			temp.WindowState = WindowState.Normal;
			temp.Activate();
		}

		// 델리게이트 이벤트 동작
        private void OnStateChanged(object parameter)
        {

            if (parameter is Window window)
            {
                switch (window.WindowState)
                {
                    case WindowState.Maximized:
                        Console.WriteLine("Window 상태: Maximized");
                        break;
                    case WindowState.Minimized:
						OnMinimizeRequested?.Invoke();

                        break;
                    case WindowState.Normal:
                        Console.WriteLine("Window 상태: Normal");
                        break;
                }
            }
        }

    }
}
