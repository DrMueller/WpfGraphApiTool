using System;
using NLog;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.Logging.Services.Implementation
{
    public class LoggingService : ILoggingService
    {
        private static readonly ILogger _logger = LogManager.GetLogger(nameof(LoggingService));

        public void LogException(Exception exception)
        {
            _logger.Error(exception);
        }

        public void LogInformation(string message)
        {
            _logger.Info(message);
        }
    }
}