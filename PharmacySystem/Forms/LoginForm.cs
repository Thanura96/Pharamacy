using System;
using System.Windows.Forms;
using PharmacySystem.Core;
using PharmacySystem.Database;
using PharmacySystem.Logging;
using PharmacySystem.Utilities;

namespace PharmacySystem.Forms
{
    public partial class LoginForm : BaseForm
    {
        private readonly ILogger _logger;

        public LoginForm()
        {
            InitializeComponent();
            _logger = new FileLogger();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            var validation = new Services.ValidationService().ValidateLogin(username, password);
            if (!validation.IsValid)
            {
                lblError.Text = validation.GetFirstError();
                return;
            }

            if (username != "Admin" || password != "admin123")
            {
                lblError.Text = "Invalid username or password!";
                txtPassword.Clear();
                txtPassword.Focus();
                _logger.LogWarning($"Failed login attempt for user '{username}'.");
                return;
            }

            lblError.Text = string.Empty;
            _logger.LogInfo($"User '{username}' logged in successfully.");

            MongoDbContext context = null;
            try
            {
                context = new MongoDbContext();
                DatabaseSeeder.Seed(context, _logger);
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to connect to MongoDB during login.", ex);
                UiHelper.ShowWarning(this,
                    "Unable to connect to MongoDB. The system will run in offline mode. " +
                    "Make sure MongoDB is running on mongodb://localhost:27017.\n\nDetails: " + ex.Message,
                    "MongoDB Connection Status");
            }

            var appContext = PharmacyAppContext.Create(context, _logger);
            Hide();

            var dashboard = new DashboardForm(appContext);
            dashboard.FormClosed += (s, args) => Close();
            dashboard.Show();
        }
    }
}
