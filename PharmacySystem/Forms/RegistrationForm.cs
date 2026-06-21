using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PharmacySystem.Core;
using PharmacySystem.Models;
using PharmacySystem.Utilities;

namespace PharmacySystem.Forms
{
    public partial class RegistrationForm : BaseForm
    {
        public RegistrationForm(PharmacyAppContext appContext) : base(appContext)
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!EnsureDatabaseAvailable()) return;

            string fullName = txtFullName.Text.Trim();
            string address = txtAddress.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Check if database contains duplicate username
            bool isDuplicate = false;
            try
            {
                var customers = AppContext.CustomerService.GetAllCustomers();
                isDuplicate = customers.Any(c => !string.IsNullOrEmpty(c.Username) && 
                                                 c.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error checking duplicate username.");
                return;
            }

            var result = ValidationService.ValidateRegistration(
                fullName, address, email, phone, username, password, confirmPassword, isDuplicate);

            UiHelper.ApplyValidationErrors(errorProvider, result.Errors, new Dictionary<string, Control>
            {
                { "FullName", txtFullName },
                { "Address", txtAddress },
                { "Email", txtEmail },
                { "Phone", txtPhone },
                { "Username", txtUsername },
                { "Password", txtPassword },
                { "ConfirmPassword", txtConfirmPassword }
            });

            if (!result.IsValid)
            {
                lblError.Text = result.GetFirstError();
                return;
            }

            lblError.Text = string.Empty;

            try
            {
                var newCustomer = new Customer
                {
                    FullName = fullName,
                    Address = address,
                    Email = email,
                    Phone = phone,
                    Username = username,
                    Password = password // In a real app we'd hash, but storing plain text matches standard LoginForm behavior
                };

                AppContext.CustomerService.AddCustomer(newCustomer);
                Logger?.LogInfo($"New customer registered successfully: {username}");
                ShowSuccess("Registration successful! You can now log in.", "Registration Success");
                Close();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Registration failed.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
