using System.Windows.Media;
using JetBrains.Annotations;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ApplicationInformations.ViewData
{
    public class InformationEntryViewData
    {
        public static string BusyIndicatorSource => "/Mmu.Mlh.WpfCoreExtensions;component/Infrastructure/Assets/FA_Cog_Green.png";
        public int? DisplayLengthInSeconds { get; }
        [UsedImplicitly] public Brush Foreground { get; }
        public string Message { get; }
        public bool ShowBusyIndicator { get; }

        public InformationEntryViewData(
            string message,
            bool showBusyIndicator,
            Brush foreground,
            int? displayLengthInSeconds)
        {
            Message = message;
            ShowBusyIndicator = showBusyIndicator;
            Foreground = foreground;
            DisplayLengthInSeconds = displayLengthInSeconds;
        }
    }
}