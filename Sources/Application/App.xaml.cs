using System.Windows;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.Orchestration.Services;

namespace Mmu.WpfGraphApiTool
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppStartService.StartAppAsync();
        }
    }
}