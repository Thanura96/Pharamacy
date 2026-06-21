using System;
using System.Linq;
using System.Windows.Forms;
using PharmacySystem.Core;
using PharmacySystem.Database;
using PharmacySystem.Logging;
using PharmacySystem.Models;
using PharmacySystem.Services;
using PharmacySystem.Utilities;

namespace PharmacySystem.Forms
{
    public partial class LoginForm : BaseForm
    {
        private readonly ILogger _logger;
        private PharmacyAppContext _appContext;

        public LoginForm()
        {
            InitializeComponent();
                _logger = new LogService();
        }

        private PharmacyAppContext GetAppContext()
        {
            if (_appContext == null)
            {
                MongoDbContext context = null;
                try
                {
                    context = new MongoDbContext();
                    DatabaseSeeder.Seed(context, _logger);
                }
                catch (Exception ex)
                {
                    _logger.LogError("Unable to connect to MongoDB.", ex);
                }
                _appContext = PharmacyAppContext.Create(context, _logger);
            }
            return _appContext;
        }

        private void rdoRole_CheckedChanged(object sender, EventArgs e)
        {
            lnkRegister.Visible = rdoCustomer.Checked;
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var appContext = GetAppContext();
            if (!appContext.IsDatabaseAvailable)
            {
                UiHelper.ShowWarning(this, "Database is offline. Customer registration is not available.", "Offline Mode");
                return;
            }

            var regForm = new RegistrationForm(appContext);
            regForm.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            var validation = new ValidationService().ValidateLogin(username, password);
            if (!validation.IsValid)
            {
                lblError.Text = validation.GetFirstError();
                return;
            }

            var appContext = GetAppContext();

            if (rdoAdmin.Checked)
            {
                // Admin Login validation
                if (username != "admin" || password != "admin123")
                {
                    lblError.Text = "Invalid admin username or password!";
                    txtPassword.Clear();
                    txtPassword.Focus();
                    _logger.LogWarning($"Failed admin login attempt for user '{username}'.");
                    return;
                }

                lblError.Text = string.Empty;
                _logger.LogInfo("Admin logged in successfully.");

                Hide();
                var adminDashboard = new AdminDashboardForm(appContext);
                adminDashboard.FormClosed += (s, args) => Close();
                adminDashboard.Show();
            }
            else
            {
                // Customer Login validation
                if (!appContext.IsDatabaseAvailable)
                {
                    lblError.Text = "Database is offline. Cannot log in as customer.";
                    return;
                }

                Customer customer = null;
                try
                {
                    customer = appContext.CustomerService.GetAllCustomers()
                        .FirstOrDefault(c => !string.IsNullOrEmpty(c.Username) &&
                                             c.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                                             c.Password == password);
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error searching for customer in database.", ex);
                    lblError.Text = "Error during login processing.";
                    return;
                }

                if (customer == null)
                {
                    lblError.Text = "Invalid customer username or password!";
                    txtPassword.Clear();
                    txtPassword.Focus();
                    _logger.LogWarning($"Failed customer login attempt for user '{username}'.");
                    return;
                }

                lblError.Text = string.Empty;
                _logger.LogInfo($"Customer '{username}' logged in successfully.");

                Hide();
                var customerDashboard = new CustomerDashboardForm(appContext, customer);
                customerDashboard.FormClosed += (s, args) => Close();
                customerDashboard.Show();
            }
        }
    }
}
