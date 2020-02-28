using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Arkanoid
{
    public class RelayCommand : ICommand
    {
        private Action<object> OnExecute;

        private Predicate<object> OnCanExecute;

        public RelayCommand(Action<object> onExecute)
        {
            this.OnExecute = onExecute;
        }

        public RelayCommand(Action<object> onExecute, Predicate<object> onCanExecute)
        {
            this.OnExecute = onExecute;
            this.OnCanExecute = onCanExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return OnCanExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            OnExecute?.Invoke(parameter);
        }
    }
}
