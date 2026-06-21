using System;
using System.Linq;
using System.Windows.Forms;
using PharmacySystem.Core;

namespace PharmacySystem.Forms
{
    public partial class AdminDashboardForm : BaseForm
    {
        public AdminDashboardForm(PharmacyAppContext appContext) : base(appContext)
        {
            InitializeComponent();
        }

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            if (!EnsureDatabaseAvailable())
            {
                lblHeaderTitle.Text = "Pharmacy Admin Dashboard (Offline)";
                return;
            }

            lblHeaderTitle.Text = "Pharmacy Admin Management Dashboard";
            Logger?.LogInfo("Admin Dashboard loaded.");
            RefreshDashboard();
        }

        private void RefreshDashboard()
        {
            try
            {
                var summary = AppContext.DashboardService.GetSummary();
                lblTotalSalesValue.Text = $"${summary.TotalSales:F2}";
                lblTotalMedicinesValue.Text = summary.TotalMedicines.ToString();
                lblLowStockValue.Text = summary.LowStockMedicines.ToString();
                lblActiveOrdersValue.Text = summary.ActiveOrders.ToString();

                var expiringSoon = AppContext.NotificationService.GetExpiringWithinDays(30);
                var expired = AppContext.NotificationService.GetExpiredMedicines();

                lstExpiringSoon.Items.Clear();
                foreach (var medicine in expiringSoon)
                {
                    lstExpiringSoon.Items.Add(
                        $"{medicine.Name} — expires {medicine.ExpiryDate:d} (Qty: {medicine.Quantity})");
                }

                if (lstExpiringSoon.Items.Count == 0)
                {
                    lstExpiringSoon.Items.Add("No medicines expiring within the next 30 days.");
                }

                lstExpired.Items.Clear();
                foreach (var medicine in expired)
                {
                    lstExpired.Items.Add(
                        $"{medicine.Name} — expired {medicine.ExpiryDate:d} (Qty: {medicine.Quantity})");
                }

                if (lstExpired.Items.Count == 0)
                {
                    lstExpired.Items.Add("No expired medicines in inventory.");
                }

                lblExpiryAlertSummary.Text = expiringSoon.Count > 0 || expired.Count > 0
                    ? $"⚠ {expiringSoon.Count} expiring soon, {expired.Count} expired"
                    : "All medicines within safe expiry range.";
            }
            catch (Exception ex)
            {
                HandleException(ex, "Failed to load dashboard summary.");
            }
        }

        private void btnRefreshDashboard_Click(object sender, EventArgs e)
        {
            if (!EnsureDatabaseAvailable()) return;
            RefreshDashboard();
        }

        private void SetActiveButton(Button activeBtn)
        {
            foreach (Control ctrl in panelSidebar.Controls)
            {
                if (ctrl is Button btn && btn != btnExit)
                {
                    btn.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
                }
            }

            if (activeBtn != null)
            {
                activeBtn.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
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

        private void btnOrders_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnOrders);
            var form = new OrderManagementForm(AppContext);
            form.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnReports);
            var form = new ReportsForm(AppContext);
            form.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (ConfirmAction("Are you sure you want to exit the Pharmacy System?", "Exit Confirmation"))
            {
                Logger?.LogInfo("Application exit requested from Admin Dashboard.");
                Application.Exit();
            }
        }
    }
}
