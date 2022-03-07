using System;
using System.Collections.Generic;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ApplicationInformations.ViewData;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ApplicationInformations.Services.Implementation
{
    public class InformationSubscriptionService : IInformationSubscriptionService
    {
        private readonly List<Action<InformationEntryViewData>> _callbacks = new List<Action<InformationEntryViewData>>();

        public void OnInformationReceived(InformationEntryViewData data)
        {
            _callbacks.ForEach(cb => cb(data));
        }

        public void Register(Action<InformationEntryViewData> callback)
        {
            _callbacks.Add(callback);
        }
    }
}