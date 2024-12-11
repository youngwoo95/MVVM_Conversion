using MDMBase.Command;
using MDMBase.Models;
using MDMBase.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

        private LockModel LockModel;

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


            ShowSettingViewFromLock = new RelayCommand(PasswordCheckClickEvent);

            OnLoadCommand = new RelayCommand(OnLoaded);
            LockModel = new LockModel();
        }

        public string PassWord
        {
            get => LockModel.PassWord ?? "";
            set
            {
                if (LockModel.PassWord != value)
                {
                    LockModel.PassWord = value;
                    OnPropertyChanged(nameof(PassWord));
                }
            }
        }

        private void PasswordCheckClickEvent(object parameter)
        {
            // 시작화면
            var mainViewModel = App.Current.Resources["MainViewModel"] as MainViewModel;
            if (mainViewModel != null)
            {
                Console.WriteLine(PassWord);
                if (PassWord.ToLower().Trim().Equals(Commons.SettingLockPassword))
                {
                    Console.WriteLine("비밀번호 동일함.");
                    CurrentView = new SettingWindow();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
