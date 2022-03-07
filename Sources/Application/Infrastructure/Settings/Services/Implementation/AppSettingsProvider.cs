using Microsoft.Extensions.Options;
using Mmu.WpfGraphApiTool.Infrastructure.Settings.Models;

namespace Mmu.WpfGraphApiTool.Infrastructure.Settings.Services.Implementation
{
    public class AppSettingsProvider : IAppSettingsProvider
    {
        private readonly IOptions<AppSettings> _settings;
        public AppSettings Settings => _settings.Value;

        public AppSettingsProvider(IOptions<AppSettings> settings)
        {
            _settings = settings;
        }
    }
}