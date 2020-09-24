using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TicTacToe
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException();
            }
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public RelayCommand(Action<object> execute) : this(execute, null) { }

        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
