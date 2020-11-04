using System;
using System.Windows.Input;

namespace Lms.Desktop.Commands
{
    public class Command<TArg> : ICommand where TArg : class
    {
        private readonly Func<TArg, bool> _canExecute;
        private readonly Action<TArg> _executeAction;
        private bool _canExecuteCache = false;

        public Command(Action<TArg> executeAction)
        {
            _executeAction = executeAction;
        }

        public Command(Action<TArg> executeAction, Func<TArg, bool> canExecute) : this(executeAction)
        {
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            var temp = _canExecuteCache;
            _canExecuteCache = _canExecute?.Invoke(parameter as TArg) ?? false;

            if (temp != _canExecuteCache)
                OnCanExecuteChanged();
            return _canExecuteCache;
        }

        public void Execute(object parameter) => _executeAction?.Invoke(parameter as TArg);

        public event EventHandler CanExecuteChanged;
        protected void OnCanExecuteChanged() => CanExecuteChanged?.Invoke(this, System.EventArgs.Empty);
    }
}