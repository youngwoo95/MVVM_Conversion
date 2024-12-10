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
        public ICommand TempCommand { get; }

        public LockViewModel()
        {
            
            TempCommand = new RelayCommand(TempClick);
        }


        private void TempClick(object parameter)
        {
            // 시작화면// LockViewModel 접근
            var lockViewModel = App.Current.Resources["LockViewModel"] as LockViewModel;
            if (lockViewModel != null)
            {
                Console.WriteLine("LockViewModel 접근 성공!");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
