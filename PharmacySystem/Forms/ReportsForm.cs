using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PharmacySystem.Core;
using PharmacySystem.Models;

namespace PharmacySystem.Forms
{
    public partial class ReportsForm : BaseForm
    {
        private List<Order> _allOrders = new List<Order>();

        public ReportsForm(PharmacyAppContext appContext) : base(appContext)
        {
            InitializeComponent();
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            if (!EnsureDatabaseAvailable()) return;
            LoadAllReports();
        }

        private void LoadAllReports()
        {
            LoadSalesReport();
            LoadStockReport();
            LoadCustomerHistory();
        }

        private void LoadSalesReport()
        {
            try
            {
                lblSalesOrderCount.Text = AppContext.ReportService.GetTotalOrderCount().ToString();
                lblSalesRevenue.Text = $"${AppContext.ReportService.GetTotalOrderRevenue():F2}";
                dgvSalesByDate.DataSource = AppContext.ReportService.GetSalesByDate();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Failed to load sales report.");
            }
        }

        private void LoadStockReport()
        {
            try
            {
                dgvCurrentStock.DataSource = AppContext.ReportService.GetCurrentStockReport();
                dgvLowStock.DataSource = AppContext.ReportService.GetLowStockReport();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Failed to load stock report.");
            }
        }

        private void LoadCustomerHistory()
        {
            try
            {
                dgvCustomerHistory.DataSource = AppContext.ReportService.GetCustomerOrderHistory();
                _allOrders = AppContext.OrderRepository.GetAllOrders();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Failed to load customer order history.");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!EnsureDatabaseAvailable()) return;
            LoadAllReports();
            ShowSuccess("Reports refreshed successfully.", "Refresh Complete");
        }

        private void tabReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!EnsureDatabaseAvailable()) return;

            switch (tabReports.SelectedIndex)
            {
                case 0: LoadSalesReport(); break;
                case 1: LoadStockReport(); break;
                case 2: LoadCustomerHistory(); break;
            }
        }

        private void btnExportHistoryPdf_Click(object sender, EventArgs e)
        {
            ExportCustomerOrderHistory(isPdf: true);
        }

        private void btnExportHistoryExcel_Click(object sender, EventArgs e)
        {
            ExportCustomerOrderHistory(isPdf: false);
        }

        private void ExportCustomerOrderHistory(bool isPdf)
        {
            if (!EnsureDatabaseAvailable()) return;

            if (_allOrders.Count == 0)
            {
                ShowWarning("There are no orders to export.", "No Data");
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                if (isPdf)
                {
                    sfd.Filter = "PDF Files|*.pdf";
                    sfd.FileName = $"CustomerOrderHistory_{DateTime.Now:yyyyMMdd}.pdf";
                }
                else
                {
                    sfd.Filter = "Excel Files|*.xls";
                    sfd.FileName = $"CustomerOrderHistory_{DateTime.Now:yyyyMMdd}.xls";
                }

                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    if (isPdf)
                    {
                        AppContext.ExportService.ExportOrdersToPdf(_allOrders, sfd.FileName, "Customer Order History");
                    }
                    else
                    {
                        AppContext.ExportService.ExportOrdersToExcel(_allOrders, sfd.FileName);
                    }

                    Logger?.LogInfo($"Admin exported customer order history to {sfd.FileName}");
                    ShowSuccess("Customer order history exported successfully!", "Export Complete");
                }
                catch (Exception ex)
                {
                    HandleException(ex, "Failed to export customer order history.");
                }
            }
        }
    }
}
