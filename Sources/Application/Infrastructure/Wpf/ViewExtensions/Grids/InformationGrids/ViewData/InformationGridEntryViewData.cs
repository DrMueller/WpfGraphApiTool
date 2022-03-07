using JetBrains.Annotations;
using Mmu.WpfGraphApiTool.Infrastructure.Invariance;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.ViewExtensions.Grids.InformationGrids.ViewData
{
    [PublicAPI]
    public class InformationGridEntryViewData
    {
        public string Message { get; }

        public InformationGridEntryViewData(string message)
        {
            Guard.StringNotNullOrEmpty(() => message);

            Message = message;
        }
    }
}