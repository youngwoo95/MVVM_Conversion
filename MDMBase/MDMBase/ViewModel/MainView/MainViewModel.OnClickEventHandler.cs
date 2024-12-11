using MDMBase.Views;

namespace MDMBase.ViewModel.MainView
{
    public partial class MainViewModel
    {
        // Command 실행 메서드
        private void HomeClickEvent(object parameter)
        {
            // 홈화면
            CurrentView = new StartWindow();
        }

        private void StartClickEvent(object parameter)
        {
            // 시작화면
            CurrentView = new StartWindow();
        }

        private void StopClickEvent(object parameter)
        {
            MessageBox.Show("중지버튼 클릭", "알림");
        }

        private void SettingClickEvent(object parameter)
        {
            // 설정화면
            var mainViewModel = App.Current.Resources["MainViewModel"] as MainViewModel;
            if (mainViewModel != null)
            {
                Console.WriteLine("잠금화면 클릭");
                CurrentView = new LockWindow();
            }
        }

        private void PasswordCheckClickEvent(object parameter)
        {
            // 시작화면
            var mainViewModel = App.Current.Resources["MainViewModel"] as MainViewModel;
            if (mainViewModel != null)
            {
                if (Password.ToLower().Trim().Equals(Commons.SettingLockPassword))
                {
                    CurrentView = new SettingWindow();
                }
                else
                {
                    MessageBox.Show("비밀번호를 확인해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }



        
    }
}
