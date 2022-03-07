using System.Threading.Tasks;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.ViewModels.Behaviors
{
    public interface IInitializableViewModel : IViewModelWithBehavior
    {
        Task InitializeAsync(params object[] initParams);
    }
}