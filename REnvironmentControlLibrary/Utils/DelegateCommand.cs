using System;
using System.Windows.Input;

namespace REnvironmentControlLibrary.Utils
{
    public class DelegateCommand : ICommand
    {
        private Action<object> _action;

        private Func<object, bool> _canExecute;

        public DelegateCommand(Action<object> action)
        {
            _action = action;
        }

        public DelegateCommand(Action<object> action, Func<object, bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;
            return _canExecute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }
}
