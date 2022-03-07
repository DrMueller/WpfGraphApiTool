using System;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ApplicationInformations.Models
{
    public class InformationEntry
    {
        public int? DisplayLengthInSeconds { get; }
        public InformationEntryType EntryType { get; }
        public string Message { get; }
        public bool ShowBusy { get; }

        private InformationEntry(string message, InformationEntryType entryType, bool showBusy, int? displayLengthInSeconds)
        {
            Message = message;
            EntryType = entryType;
            ShowBusy = showBusy;
            DisplayLengthInSeconds = displayLengthInSeconds;
        }

        public static InformationEntry CreateEmpty()
        {
            return new InformationEntry(string.Empty, InformationEntryType.Info, false, null);
        }

        public static InformationEntry CreateError(Exception exception)
        {
            return new InformationEntry(exception.Message, InformationEntryType.Error, false, null);
        }

        public static InformationEntry CreateError(string errorMessage)
        {
            return new InformationEntry(errorMessage, InformationEntryType.Error, false, null);
        }

        public static InformationEntry CreateInfo(string infoMessage, bool showBusy, int? displayLengthInSeconds = null)
        {
            return new InformationEntry(infoMessage, InformationEntryType.Info, showBusy, displayLengthInSeconds);
        }

        public static InformationEntry CreateSuccess(string successMessage, bool showBusy, int? displayLengthInSeconds = null)
        {
            return new InformationEntry(successMessage, InformationEntryType.Success, showBusy, displayLengthInSeconds);
        }
    }
}