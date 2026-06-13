using System;
using System.Threading;
using System.Windows.Forms;
using PharmacySystem.Logging;
using PharmacySystem.Utilities;

namespace PharmacySystem.Infrastructure
{
    public static class GlobalExceptionHandler
    {
        private static ILogger _logger;

        public static void Register(ILogger logger)
        {
            _logger = logger;

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += OnThreadException;
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
        }

        private static void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            HandleException(e.Exception, "An unexpected error occurred in the application.");
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;
            HandleException(exception, "A critical error occurred and the application must close.");
        }

        private static void HandleException(Exception exception, string userMessage)
        {
            if (exception == null)
            {
                return;
            }

            _logger?.LogError(userMessage, exception);
            UiHelper.ShowError(null, $"{userMessage}{Environment.NewLine}{Environment.NewLine}Details: {exception.Message}");
        }
    }
}
