using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMBase.ViewModel.SettingView
{
    public partial class SettingViewModel
    {
        private void ConnCheckEvent(object parameter)
        {
            Console.WriteLine("연결 검사 이벤트");
        }

        private void ConnSaveEvent(object parameter)
        {
            Console.WriteLine("저장 버튼 이벤트");
        }

    }
}
