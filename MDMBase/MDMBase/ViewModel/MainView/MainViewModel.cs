using MDMBase.Command;
using MDMBase.ViewModel.LockView;
using MDMBase.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

using UserControl = System.Windows.Controls.UserControl;

namespace MDMBase.ViewModel.MainView
{
    /// <summary>
    /// VIEW MODEL
    /// </summary>
    public partial class MainViewModel : INotifyPropertyChanged
    {
        public ICommand btnHomeCommand { get; }
        public ICommand btnStartCommand { get; }
        public ICommand btnStopCommand { get; }
        public ICommand btnSettingCommand { get; }
        public ICommand OnLoadCommand { get; }
       
        // 테스트
        public ICommand ShowSettingViewFromLock { get; }

      

        // 화면변경
        private UserControl _currentView;

        public UserControl CurrentView
        {
            get
            {
                return _currentView;
            }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            btnHomeCommand = new RelayCommand(HomeClickEvent);
            btnStartCommand = new RelayCommand(StartClickEvent);
            btnStopCommand = new RelayCommand(StopClickEvent);
            btnSettingCommand = new RelayCommand(SettingClickEvent);


            ShowSettingViewFromLock = new RelayCommand(TempClick);

            OnLoadCommand = new RelayCommand(OnLoaded);

        }

        private void TempClick(object parameter)
        {
            // 시작화면
            var mainViewModel = App.Current.Resources["MainViewModel"] as MainViewModel;
            if (mainViewModel != null)
            {
                Console.WriteLine("동작?");
                CurrentView = new SettingWindow();
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
