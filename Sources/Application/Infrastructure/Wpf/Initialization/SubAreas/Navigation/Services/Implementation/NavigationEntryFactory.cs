using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.SubAreas.Navigation.Models;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.CommandManagement.Commands;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.ViewModels;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.ViewModels.Behaviors;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.ViewModels.Services;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.SubAreas.Navigation.Services.Implementation
{
    public class NavigationEntryFactory : INavigationEntryFactory
    {
        private readonly IServiceProvider _serviceLocator;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IViewModelDisplayService _vmDisplayService;

        public NavigationEntryFactory(
            IViewModelDisplayService vmDisplayService,
            IViewModelFactory viewModelFactory,
            IServiceProvider serviceLocator)
        {
            _vmDisplayService = vmDisplayService;
            _viewModelFactory = viewModelFactory;
            _serviceLocator = serviceLocator;
        }

        public async Task<IReadOnlyCollection<NavigationEntry>> CreateAllAsync()
        {
            var navigatableViewModelTypes =
                _serviceLocator
                    .GetServices<IViewModel>()
                    .OfType<INavigatableViewModel>()
                    .Select(f => f.GetType())
                    .ToList();

            var tasks = navigatableViewModelTypes.Select(type => _viewModelFactory.CreateAsync(type));
            var navigationViewModels = await Task.WhenAll(tasks);

            var result = navigationViewModels
                .Cast<INavigatableViewModel>()
                .OrderBy(f => f.NavigationSequence)
                .Select(CreateNavigationEntry)
                .ToList();

            return result;
        }

        private NavigationEntry CreateNavigationEntry(INavigatableViewModel viewModel)
        {
            var navigationCommand = new RelayCommand(
                () =>
                {
                    _vmDisplayService.DisplayAsync(viewModel.GetType());
                });

            return new NavigationEntry(navigationCommand, viewModel.NavigationDescription);
        }
    }
}