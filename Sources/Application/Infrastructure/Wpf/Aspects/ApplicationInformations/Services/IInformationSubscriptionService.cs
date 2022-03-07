using System;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ApplicationInformations.ViewData;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ApplicationInformations.Services
{
    public interface IInformationSubscriptionService
    {
        void OnInformationReceived(InformationEntryViewData data);

        void Register(Action<InformationEntryViewData> callback);
    }
}