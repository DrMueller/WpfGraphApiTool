using System;
using System.Threading.Tasks;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.ViewModels.Services
{
    public interface IViewModelFactory
    {
        Task<IViewModel> CreateAsync(Type viewModelType);

        Task<T> CreateAsync<T>(params object[] initParams)
            where T : IViewModel;
    }
}