using System;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.ViewModels.Behaviors;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.ViewModels.Services.Implementation
{
    public class ViewModelDisplayConfigurationService : IViewModelDisplayConfigurationService
    {
        private Action<IDisplayableViewModel> _navigationCallback;

        public void Initialize(Action<IDisplayableViewModel> navigationCallback)
        {
            _navigationCallback = navigationCallback;
        }

        public void OnDisplay(IDisplayableViewModel viewModel)
        {
            _navigationCallback(viewModel);
        }
    }
}