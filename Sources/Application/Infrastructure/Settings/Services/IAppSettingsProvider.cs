using Mmu.WpfGraphApiTool.Infrastructure.Settings.Models;

namespace Mmu.WpfGraphApiTool.Infrastructure.Settings.Services
{
    public interface IAppSettingsProvider
    {
        AppSettings Settings { get; }
    }
}