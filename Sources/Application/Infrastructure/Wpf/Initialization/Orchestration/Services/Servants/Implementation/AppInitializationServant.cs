using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using JetBrains.Annotations;
using Mmu.WpfGraphApiTool.Infrastructure.TypeExtensions.Assemblies;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ApplicationInformations.Models;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ApplicationInformations.Services;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ExceptionHandling.Services;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.SubAreas.ViewModelMapping.Services;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.Container;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.Orchestration.Services.Servants.Implementation
{
    [UsedImplicitly]
    public class AppInitializationServant : IAppInitializationServant
    {
        private readonly IExceptionInitializationService _exceptionInitializationService;
        private readonly IInformationPublisher _infoPublisher;
        private readonly IViewModelContainer _viewModelContainer;
        private readonly IViewModelMappingInitializationService _viewModelMappingInitService;

        public AppInitializationServant(
            IViewModelMappingInitializationService viewModelMappingInitService,
            IViewModelContainer viewModelContainer,
            IExceptionInitializationService exceptionInitializationService,
            IInformationPublisher infoPublisher)
        {
            _viewModelMappingInitService = viewModelMappingInitService;
            _viewModelContainer = viewModelContainer;
            _exceptionInitializationService = exceptionInitializationService;
            _infoPublisher = infoPublisher;
        }

        public async Task StartAppAsync()
        {
            _exceptionInitializationService.HookGlobalExceptions();
            _viewModelMappingInitService.Initialize();
            await _viewModelContainer.InitializeAsync();
            _infoPublisher.Publish(InformationEntry.CreateInfo("Here could be your text..", false));
            ShowApp();
        }

        private static ImageSource CreateDefaultImageSource()
        {
            var assemblyBasePath = typeof(AppInitializationServant).Assembly.GetBasePath();
            var iconPath = Path.Combine(assemblyBasePath, "Infrastructure", "Assets", "App.ico");
            var iconUri = new Uri(iconPath);
            var icon = new BitmapImage(iconUri);

            return icon;
        }

        private void ShowApp()
        {
            var viewContainer = new ViewContainer
            {
                DataContext = _viewModelContainer,
                Title = "Graph API WPF Test",
                Icon = CreateDefaultImageSource(),
                Width = 1200,
                Height = 800
            };

            viewContainer.ShowDialog();
        }
    }
}