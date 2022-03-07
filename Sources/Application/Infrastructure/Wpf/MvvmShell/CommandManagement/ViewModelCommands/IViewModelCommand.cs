using System.Windows.Input;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.CommandManagement.ViewModelCommands
{
    public interface IViewModelCommand
    {
        ICommand Command { get; }
        string Description { get; }
    }
}