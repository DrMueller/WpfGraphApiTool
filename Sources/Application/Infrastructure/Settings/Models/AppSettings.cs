using JetBrains.Annotations;

namespace Mmu.WpfGraphApiTool.Infrastructure.Settings.Models
{
    [PublicAPI]
    public class AppSettings
    {
        public const string SectionKey = "AppSettings";
        public string GraphApiClientId { get; set; }
        public string GraphApiTenantId { get; set; }
    }
}