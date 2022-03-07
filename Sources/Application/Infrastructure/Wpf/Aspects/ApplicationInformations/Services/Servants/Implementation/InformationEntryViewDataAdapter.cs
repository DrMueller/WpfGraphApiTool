using System.Windows.Media;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ApplicationInformations.Models;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ApplicationInformations.ViewData;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ApplicationInformations.Services.Servants.Implementation
{
    public class InformationEntryViewDataAdapter : IInformationEntryViewDataAdapter
    {
        public InformationEntryViewData Adapt(InformationEntry infoEntry)
        {
            var brush = AdaptBrush(infoEntry.EntryType);

            return new InformationEntryViewData(
                infoEntry.Message,
                infoEntry.ShowBusy,
                brush,
                infoEntry.DisplayLengthInSeconds);
        }

        // TODO: Create Brush map
        private static Brush AdaptBrush(InformationEntryType entryType)
        {
            switch (entryType)
            {
                case InformationEntryType.Info:
                {
                    return Brushes.Black;
                }

                case InformationEntryType.Success:
                {
                    return Brushes.DarkGreen;
                }

                case InformationEntryType.Error:
                {
                    return Brushes.DarkRed;
                }

                default:
                {
                    return Brushes.Black;
                }
            }
        }
    }
}