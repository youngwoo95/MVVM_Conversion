using System.Windows.Input;

namespace MDMBase.Command
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            if(_canExecute != null)
            {
                return _canExecute.Invoke(parameter);
            }
            return true;
        }

        public void Execute(object? parameter)
        {
            if(_execute != null)
            {
                _execute.Invoke(parameter);
            }
        }

        public event EventHandler? CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

    }
}
