using System;
using System.Threading.Tasks;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.ViewModels.Behaviors;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.ViewModels.Services.Implementation
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly IServiceProvider _serviceLocator;

        public ViewModelFactory(IServiceProvider serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public async Task<T> CreateAsync<T>(params object[] initParams)
            where T : IViewModel
        {
            return (T)await CreateAsync(typeof(T), initParams);
        }

        public async Task<IViewModel> CreateAsync(Type viewModelType)
        {
            return await CreateAsync(viewModelType, null);
        }

        private async Task<IViewModel> CreateAsync(Type viewModelType, params object[] initParams)
        {
            var viewModelBaseType = typeof(IViewModel);

            if (!viewModelBaseType.IsAssignableFrom(viewModelType))
            {
                throw new ArgumentException($"{viewModelType.Name} is not assignable from IViewModel.");
            }

            var result = (IViewModel)_serviceLocator.GetService(viewModelType);

            if (result is IInitializableViewModel initializable)
            {
                await initializable.InitializeAsync(initParams);
            }

            return result;
        }
    }
}