using MDMBase.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            CurrentView = new SettingWindow();
        }
    }
}
