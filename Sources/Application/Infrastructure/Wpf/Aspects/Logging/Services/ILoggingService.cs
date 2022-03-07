using System;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.Logging.Services
{
    public interface ILoggingService
    {
        void LogException(Exception exception);

        void LogInformation(string message);
    }
}