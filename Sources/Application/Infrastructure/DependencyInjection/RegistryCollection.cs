using JetBrains.Annotations;
using Lamar;
using Mmu.WpfGraphApiTool.Infrastructure.GraphApi.Services;
using Mmu.WpfGraphApiTool.Infrastructure.GraphApi.Services.Implementation;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ApplicationInformations.Services;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ApplicationInformations.Services.Implementation;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ApplicationInformations.Services.Servants;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ApplicationInformations.Services.Servants.Implementation;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ExceptionHandling.Services;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ExceptionHandling.Services.Implementation;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.Logging.Services;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.Logging.Services.Implementation;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.Orchestration.Services.Servants;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.Orchestration.Services.Servants.Implementation;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.SubAreas.Navigation.Services;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.SubAreas.Navigation.Services.Implementation;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.SubAreas.ViewModelMapping.Services;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.SubAreas.ViewModelMapping.Services.Implementation;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.SubAreas.ViewModelMapping.Services.Servants;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.SubAreas.ViewModelMapping.Services.Servants.Implementation;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.Container;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.ViewModels;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.ViewModels.Services;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.ViewModels.Services.Implementation;

namespace Mmu.WpfGraphApiTool.Infrastructure.DependencyInjection
{
    [UsedImplicitly]
    public class RegistryCollection : ServiceRegistry
    {
        public RegistryCollection()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<RegistryCollection>();
                    scanner.AddAllTypesOf<IViewModel>();
                    scanner.WithDefaultConventions();
                });

            // Aspects
            For<IExceptionHandler>().Use<ExceptionHandler>().Singleton();
            For<IExceptionInitializationService>().Use<ExceptionInitializationService>().Singleton();

            For<IInformationPublisher>().Use<InformationPublisher>().Singleton();
            For<IInformationSubscriptionService>().Use<InformationSubscriptionService>().Singleton();
            For<IInformationEntryViewDataAdapter>().Use<InformationEntryViewDataAdapter>().Singleton();

            For<ILoggingService>().Use<LoggingService>().Singleton();

            // Initialization
            For<IAppInitializationServant>().Use<AppInitializationServant>().Singleton();

            For<IViewModelMappingInitializationService>().Use<ViewModelMappingInitializationService>().Singleton();
            For<INavigationEntryFactory>().Use<NavigationEntryFactory>().Singleton();
            For<IResourceDictionaryFactory>().Use<ResourceDictionaryFactory>().Singleton();
            For<IViewViewModelMapFactory>().Use<ViewViewModelMapFactory>().Singleton();
            For<IDataTemplateFactory>().Use<DataTemplateFactory>().Singleton();

            // MvvmShell
            For<IViewModelContainer>().Use<ViewModelContainer>().Singleton();
            For<IViewModelDisplayConfigurationService>().Use<ViewModelDisplayConfigurationService>().Singleton();
            For<IViewModelDisplayService>().Use<ViewModelDisplayService>().Singleton();
            For<IViewModelFactory>().Use<ViewModelFactory>().Singleton();

            // Business-Services
            For<IGraphServiceClientFactory>().Use<GraphServiceClientFactory>().Singleton();
        }
    }
}