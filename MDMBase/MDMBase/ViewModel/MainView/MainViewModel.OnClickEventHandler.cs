using MDMBase.Views;
using Microsoft.Extensions.DependencyInjection;

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
            // DI 컨테이너에서 LockWindow 인스턴스를 가져옵니다.
            var lockWindow = App.ServiceProvider.GetRequiredService<LockWindow>();

            if (lockWindow != null)
            {
                Console.WriteLine("잠금화면 클릭");
                CurrentView = lockWindow; // 현재 View를 LockWindow로 변경
            }
        }

        private void PasswordCheckClickEvent(object parameter)
        {
            // LockWindow를 DI 컨테이너에서 가져오기
            var lockWindow = App.ServiceProvider.GetRequiredService<LockWindow>();

            if (lockWindow != null)
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
