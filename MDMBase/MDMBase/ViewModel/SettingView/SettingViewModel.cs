using MDMBase.Command;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MDMBase.ViewModel.SettingView
{
    /// <summary>
    /// VIEW MODEL
    /// </summary>
    public partial class SettingViewModel : INotifyPropertyChanged
    {
        public ICommand btnConnCheckCommand { get; }
        public ICommand btnSaveCommand { get; }
        public ICommand OnLoadCommand { get; }

        public SettingViewModel()
        {
            btnConnCheckCommand = new RelayCommand(ConnCheckEvent);
            btnSaveCommand = new RelayCommand(ConnSaveEvent);
            OnLoadCommand = new RelayCommand(OnLoaded);
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }


}
