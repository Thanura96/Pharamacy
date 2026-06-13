using System;
using System.Drawing;
using System.Windows.Forms;
using PharmacySystem.Core;
using PharmacySystem.Logging;
using PharmacySystem.Services.Interfaces;
using PharmacySystem.Utilities;

namespace PharmacySystem.Forms
{
    public abstract class BaseForm : Form
    {
        protected PharmacyAppContext AppContext { get; }
        protected ILogger Logger => AppContext?.Logger;
        protected IValidationService ValidationService => AppContext?.ValidationService;

        protected BaseForm()
        {
        }

        protected BaseForm(PharmacyAppContext appContext)
        {
            AppContext = appContext;
            Font = new Font("Segoe UI", 9F);
            StartPosition = FormStartPosition.CenterScreen;
        }

        protected bool EnsureDatabaseAvailable()
        {
            if (AppContext != null && AppContext.IsDatabaseAvailable)
            {
                return true;
            }

            UiHelper.ShowWarning(this, "Database is not available. Please ensure MongoDB is running and restart the application.", "Offline Mode");
            return false;
        }

        protected void ShowSuccess(string message, string title = "Success")
        {
            UiHelper.ShowInfo(this, message, title);
        }

        protected void ShowWarning(string message, string title = "Warning")
        {
            UiHelper.ShowWarning(this, message, title);
        }

        protected void ShowError(string message, string title = "Error")
        {
            UiHelper.ShowError(this, message, title);
        }

        protected bool ConfirmAction(string message, string title = "Confirm")
        {
            return UiHelper.Confirm(this, message, title);
        }

        protected void HandleException(Exception ex, string userMessage)
        {
            Logger?.LogError(userMessage, ex);
            ShowError($"{userMessage}{Environment.NewLine}{Environment.NewLine}Details: {ex.Message}");
        }
    }
}
