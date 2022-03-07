using System.Threading.Tasks;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.Orchestration.Services.Servants
{
    public interface IAppInitializationServant
    {
        Task StartAppAsync();
    }
}