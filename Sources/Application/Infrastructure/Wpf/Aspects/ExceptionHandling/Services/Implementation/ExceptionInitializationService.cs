using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ExceptionHandling.Services.Implementation
{
    public class ExceptionInitializationService : IExceptionInitializationService
    {
        private readonly IExceptionHandler _exceptionHandler;

        public ExceptionInitializationService(IExceptionHandler exceptionHandler)
        {
            _exceptionHandler = exceptionHandler;
        }

        public void HookGlobalExceptions()
        {
            Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
        }

        private void Current_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }

            _exceptionHandler.Handle(e.Exception);
            e.Handled = true;
        }
    }
}