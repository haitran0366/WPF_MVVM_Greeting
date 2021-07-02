using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_MVVM_Greeting
{
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action action):this(action,() => true)
        {
            _execute = action;
        }
        public RelayCommand(Action action,Func<bool> canExecute)
        {
            _execute = action;
            _canExecute = canExecute;
        }
        event EventHandler ICommand.CanExecuteChanged
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

        bool ICommand.CanExecute(object parameter)
        {
            return _canExecute();
        }

        void ICommand.Execute(object parameter)
        {
            _execute();
        }
    }
}
