using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ApplicationInformations.Models;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ApplicationInformations.Services.Servants;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ApplicationInformations.ViewData;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ApplicationInformations.Services.Implementation
{
    public class InformationPublisher : IInformationPublisher
    {
        private readonly Queue<InformationEntryViewData> _informationEntriesQueue = new Queue<InformationEntryViewData>();
        private readonly IInformationSubscriptionService _subscriptionService;
        private readonly IInformationEntryViewDataAdapter _viewDataAdapter;
        private bool _publishingInProgress;

        public InformationPublisher(
            IInformationEntryViewDataAdapter viewDataAdapter,
            IInformationSubscriptionService subscriptionService)
        {
            _viewDataAdapter = viewDataAdapter;
            _subscriptionService = subscriptionService;
        }

        public void Publish(InformationEntry infoEntry)
        {
            var viewData = _viewDataAdapter.Adapt(infoEntry);
            _informationEntriesQueue.Enqueue(viewData);
            CheckAndPublish();
        }

        [SuppressMessage("Usage", "VSTHRD110:Observe result of async calls", Justification = "Fire and forget")]
        private void CheckAndPublish()
        {
            if (!_informationEntriesQueue.Any() || _publishingInProgress)
            {
                return;
            }

            _publishingInProgress = true;

            var nextEntry = _informationEntriesQueue.Dequeue();
            _subscriptionService.OnInformationReceived(nextEntry);

            if (nextEntry.DisplayLengthInSeconds.HasValue)
            {
                Task.Run(
                    async () =>
                    {
                        await Task.Delay(nextEntry.DisplayLengthInSeconds.Value * 1000);
                        var emptyInfo = _viewDataAdapter.Adapt(InformationEntry.CreateEmpty());
                        _subscriptionService.OnInformationReceived(emptyInfo);
                        _publishingInProgress = false;
                        CheckAndPublish();
                    });
            }
            else
            {
                _publishingInProgress = false;
            }
        }
    }
}