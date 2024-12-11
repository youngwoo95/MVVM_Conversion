using MDMBase.Command;
using MDMBase.Models;
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
        
        /* LOCK 화면에서 비밀번호 검사 */
        public ICommand ShowSettingViewFromLock { get; }
        /* LOCK 화면에서 비밀번호 검사 */
        public ICommand EnterKeyCommand { get; }

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
            LockModel = new LockModel();
            btnHomeCommand = new RelayCommand(HomeClickEvent);
            btnStartCommand = new RelayCommand(StartClickEvent);
            btnStopCommand = new RelayCommand(StopClickEvent);
            btnSettingCommand = new RelayCommand(SettingClickEvent);

            ShowSettingViewFromLock = new RelayCommand(PasswordCheckClickEvent);
            EnterKeyCommand = new RelayCommand(PasswordCheckClickEvent);
            OnLoadCommand = new RelayCommand(OnLoaded);
        }
   
        public string Password
        {
            get => LockModel.Password ?? "";
            set
            {
                if (LockModel.Password != value)
                {
                    LockModel.Password = value;
                    OnPropertyChanged();
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
