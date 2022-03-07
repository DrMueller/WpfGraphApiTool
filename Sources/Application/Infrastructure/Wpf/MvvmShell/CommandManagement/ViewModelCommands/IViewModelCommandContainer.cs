using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.ViewModels;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.CommandManagement.ViewModelCommands
{
    [PublicAPI]
    public interface IViewModelCommandContainer<in T>
        where T : IViewModel
    {
        Task InitializeAsync(T context);
    }
}