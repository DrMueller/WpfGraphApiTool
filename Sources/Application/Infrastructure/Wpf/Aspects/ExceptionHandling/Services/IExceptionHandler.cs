using System;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ExceptionHandling.Services
{
    public interface IExceptionHandler
    {
        void Handle(Exception exception);
    }
}