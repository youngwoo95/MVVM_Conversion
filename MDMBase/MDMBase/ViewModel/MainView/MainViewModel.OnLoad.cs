using System.IO;
using System.Windows;

namespace MDMBase.ViewModel.MainView
{
    public partial class MainViewModel
	{
		private NotifyIcon? notifyIcon;

		


		/// <summary>
		/// LOAD 이벤트
		/// </summary>
		/// <param name="parameter"></param>
		private void OnLoaded(object parameter)
		{
			Console.WriteLine("실행");

        }

	

		// 델리게이트 이벤트 동작
        private void OnStateChanged(object parameter)
        {

            if (parameter is Window window)
            {
                switch (window.WindowState)
                {
                    case WindowState.Maximized:
                        window.Hide();
                        break;
                    case WindowState.Minimized:
						window.Hide();

                        break;
                    case WindowState.Normal:
						window.Show();
                        
                        break;
                }
            }
        }

    }
}
