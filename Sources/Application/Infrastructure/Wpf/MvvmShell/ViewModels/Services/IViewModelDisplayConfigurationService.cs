using System;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.ViewModels.Behaviors;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.ViewModels.Services
{
    public interface IViewModelDisplayConfigurationService
    {
        void Initialize(Action<IDisplayableViewModel> navigationCallback);

        void OnDisplay(IDisplayableViewModel viewModel);
    }
}