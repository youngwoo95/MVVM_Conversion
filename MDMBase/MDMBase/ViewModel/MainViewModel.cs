using MDMBase.Command;
using MDMBase.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MDMBase.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ICommand btnHomeCommand { get; }
        public ICommand btnStartCommand { get; }
        public ICommand btnStopCommand { get; }
        public ICommand btnSettingCommand { get; }
        public ICommand OnLoadCommand { get; }

        // 화면변경
        private System.Windows.Controls.UserControl _currentView;

        public System.Windows.Controls.UserControl CurrentView
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

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainViewModel()
        {
            btnHomeCommand = new RelayCommand(HomeClickEvent);
            btnStartCommand = new RelayCommand(StartClickEvent);
            btnStopCommand = new RelayCommand(StopClickEvent);
            btnSettingCommand = new RelayCommand(SettingClickEvent);

            OnLoadCommand = new RelayCommand(OnLoaded);
        }

        /// <summary>
        /// LOAD 이벤트
        /// </summary>
        /// <param name="parameter"></param>
        private void OnLoaded(object parameter)
        {
            Console.WriteLine("LOAD 이벤트");
        }

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
