using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.CommandManagement.Commands
{
    public class AsyncRelayCommand : ICommand
    {
        private readonly Func<Task> _action;
        private readonly Func<bool> _canExecute;

        public AsyncRelayCommand(Func<Task> action, Func<bool> canExecute = null)
        {
            _canExecute = canExecute;
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }

        [SuppressMessage("Usage", "VSTHRD100:Avoid async void methods", Justification = "Need to use ICommand interface")]
        public async void Execute(object parameter)
        {
            await _action();
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}