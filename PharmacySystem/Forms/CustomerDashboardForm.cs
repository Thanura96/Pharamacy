using System;
using System.Drawing;
using System.Windows.Forms;
using PharmacySystem.Core;
using PharmacySystem.Models;
using PharmacySystem.Services;
using PharmacySystem.Services.Interfaces;

namespace PharmacySystem.Forms
{
    public partial class CustomerDashboardForm : BaseForm
    {
        private readonly Customer _loggedCustomer;
        private readonly ICartService _cartService;

        public CustomerDashboardForm(PharmacyAppContext appContext, Customer customer) : base(appContext)
        {
            InitializeComponent();
            _loggedCustomer = customer;
            _cartService = new CartService(appContext.MedicineService);
        }

        private void CustomerDashboardForm_Load(object sender, EventArgs e)
        {
            if (!EnsureDatabaseAvailable())
            {
                lblHeaderTitle.Text = $"Welcome, {_loggedCustomer.FullName} (Offline)";
            }
            else
            {
                lblHeaderTitle.Text = $"Welcome, {_loggedCustomer.FullName}";
                Logger?.LogInfo($"Customer '{_loggedCustomer.Username}' dashboard loaded.");
            }

            ShowWelcomePanel();
        }

        private void ShowWelcomePanel()
        {
            panelContent.Controls.Clear();

            var welcomePanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 247, 250),
                Padding = new Padding(40)
            };

            var lblWelcome = new Label
            {
                Text = "Welcome to SmartMed Pharmacy",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 62, 80),
                AutoSize = true,
                Location = new Point(40, 40)
            };

            var lblInstructions = new Label
            {
                Text = "Use the sidebar to search medicines, manage your cart, track orders, and view your profile.",
                Font = new Font("Segoe UI", 11F),
                ForeColor = Color.FromArgb(127, 140, 141),
                AutoSize = true,
                Location = new Point(42, 90)
            };

            welcomePanel.Controls.Add(lblWelcome);
            welcomePanel.Controls.Add(lblInstructions);
            panelContent.Controls.Add(welcomePanel);
        }

        private void SetActiveButton(Button activeBtn)
        {
            foreach (Control ctrl in panelSidebar.Controls)
            {
                if (ctrl is Button btn && btn != btnLogout)
                {
                    btn.BackColor = Color.FromArgb(44, 62, 80);
                }
            }

            if (activeBtn != null)
            {
                activeBtn.BackColor = Color.FromArgb(52, 152, 219);
            }
        }

        private void btnSearchMedicines_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnSearchMedicines);
            var form = new SearchMedicineForm(AppContext, _cartService);
            form.Show();
        }

        private void btnMyCart_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnMyCart);
            var form = new MyCartForm(AppContext, _cartService, _loggedCustomer);
            form.Show();
        }

        private void btnMyOrders_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnMyOrders);
            var form = new MyOrdersForm(AppContext, _loggedCustomer);
            form.Show();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnProfile);
            var form = new CustomerProfileForm(AppContext, _loggedCustomer);
            form.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (ConfirmAction("Are you sure you want to log out?", "Logout"))
            {
                Logger?.LogInfo($"Customer '{_loggedCustomer.Username}' logged out.");
                Hide();
                var login = new LoginForm();
                login.Show();
            }
        }
    }
}
