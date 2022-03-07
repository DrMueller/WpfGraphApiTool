using System.Threading.Tasks;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.Container
{
    public interface IViewModelContainer
    {
        Task InitializeAsync();
    }
}