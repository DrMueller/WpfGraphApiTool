using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.Orchestration.Services.Servants;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.Orchestration.Services
{
    public static class AppStartService
    {
        public static async Task StartAppAsync()
        {
            var host = HostFactory.Create();
            var initServant = host.Services.GetRequiredService<IAppInitializationServant>();
            await initServant.StartAppAsync();
        }
    }
}