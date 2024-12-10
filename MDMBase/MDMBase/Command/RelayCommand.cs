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

        // 해당 이벤트 사용가능한지?
        public bool CanExecute(object? parameter)
        {
            if(_canExecute != null)
            {
                return _canExecute.Invoke(parameter);
            }
            return true;
        }

        // 이벤트 실행
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
