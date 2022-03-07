using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ApplicationInformations.Models;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ApplicationInformations.ViewData;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ApplicationInformations.Services.Servants
{
    public interface IInformationEntryViewDataAdapter
    {
        InformationEntryViewData Adapt(InformationEntry infoEntry);
    }
}