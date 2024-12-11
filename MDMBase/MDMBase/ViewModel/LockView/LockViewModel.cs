using MDMBase.Command;
using MDMBase.ViewModel.MainView;
using MDMBase.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using UserControl = System.Windows.Controls.UserControl;

namespace MDMBase.ViewModel.LockView
{
    public partial class LockViewModel : INotifyPropertyChanged
    {

        public LockViewModel()
        {
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
