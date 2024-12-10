﻿using MDMBase.Command;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

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

        public MainViewModel()
        {
            btnHomeCommand = new RelayCommand(HomeClickEvent);
            btnStartCommand = new RelayCommand(StartClickEvent);
            btnStopCommand = new RelayCommand(StopClickEvent);
            btnSettingCommand = new RelayCommand(SettingClickEvent);
            

            OnLoadCommand = new RelayCommand(OnLoaded);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
