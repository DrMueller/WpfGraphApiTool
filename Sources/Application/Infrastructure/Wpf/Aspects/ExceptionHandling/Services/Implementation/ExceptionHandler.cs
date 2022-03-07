using System;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ApplicationInformations.Models;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ApplicationInformations.Services;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.Logging.Services;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ExceptionHandling.Services.Implementation
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly IInformationPublisher _informationPublisher;
        private readonly ILoggingService _loggingService;

        public ExceptionHandler(
            ILoggingService loggingService,
            IInformationPublisher informationPublisher)
        {
            _loggingService = loggingService;
            _informationPublisher = informationPublisher;
        }

        public void Handle(Exception exception)
        {
            _loggingService.LogException(exception);
            _informationPublisher.Publish(InformationEntry.CreateError(exception));
        }
    }
}