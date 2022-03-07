using System;
using System.Threading.Tasks;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.ViewModels.Behaviors;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.ViewModels.Services
{
    public interface IViewModelDisplayService
    {
        Task DisplayAsync<T>(params object[] initParams)
            where T : IDisplayableViewModel;

        Task DisplayAsync(Type targetType);
    }
}