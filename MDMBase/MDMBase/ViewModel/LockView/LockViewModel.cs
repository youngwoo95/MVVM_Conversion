using System.ComponentModel;
using System.Runtime.CompilerServices;

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
