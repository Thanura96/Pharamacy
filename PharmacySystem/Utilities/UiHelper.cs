using System.Collections.Generic;
using System.Windows.Forms;

namespace PharmacySystem.Utilities
{
    public static class UiHelper
    {
        public static void ShowInfo(IWin32Window owner, string message, string title = "Information")
        {
            MessageBox.Show(owner, message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowWarning(IWin32Window owner, string message, string title = "Warning")
        {
            MessageBox.Show(owner, message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowError(IWin32Window owner, string message, string title = "Error")
        {
            MessageBox.Show(owner, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool Confirm(IWin32Window owner, string message, string title = "Confirm")
        {
            return MessageBox.Show(owner, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static void ApplyValidationErrors(ErrorProvider errorProvider, Dictionary<string, string> errors, Dictionary<string, Control> fieldMap)
        {
            errorProvider.Clear();
            foreach (var mapping in fieldMap)
            {
                if (errors.ContainsKey(mapping.Key))
                {
                    errorProvider.SetError(mapping.Value, errors[mapping.Key]);
                }
                else
                {
                    errorProvider.SetError(mapping.Value, string.Empty);
                }
            }
        }
    }
}
