using System;
using System.Drawing;
using System.Windows.Forms;
using PharmacySystem.Core;

namespace PharmacySystem.Forms
{
    public partial class DashboardForm : BaseForm
    {
        public DashboardForm(PharmacyAppContext appContext) : base(appContext)
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            if (!EnsureDatabaseAvailable())
            {
                lblHeaderTitle.Text = "Pharmacy Dashboard (Offline)";
            }
            else
            {
                lblHeaderTitle.Text = "Pharmacy Management Dashboard";
                Logger?.LogInfo("Dashboard loaded.");
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
                Text = "Welcome to the Pharmacy Management System",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 62, 80),
                AutoSize = true,
                Location = new Point(40, 40)
            };

            var lblInstructions = new Label
            {
                Text = "Use the navigation menu to manage medicines, customers, sales, and reports.",
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
                if (ctrl is Button btn && btn != btnExit)
                {
                    btn.BackColor = Color.FromArgb(44, 62, 80);
                }
            }

            if (activeBtn != null)
            {
                activeBtn.BackColor = Color.FromArgb(52, 152, 219);
            }
        }

        private void btnMedicines_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnMedicines);
            var form = new MedicineForm(AppContext);
            form.Show();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnCustomers);
            var form = new CustomerForm(AppContext);
            form.Show();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnSales);
            var form = new SalesForm(AppContext);
            form.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnReports);
            var form = new ReportForm(AppContext);
            form.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (ConfirmAction("Are you sure you want to exit the Pharmacy System?", "Exit Confirmation"))
            {
                Logger?.LogInfo("Application exit requested from dashboard.");
                Application.Exit();
            }
        }
    }
}
