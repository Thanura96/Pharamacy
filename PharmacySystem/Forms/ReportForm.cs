using System;
using System.Linq;
using System.Windows.Forms;
using PharmacySystem.Core;

namespace PharmacySystem.Forms
{
    public partial class ReportForm : BaseForm
    {
        public ReportForm(PharmacyAppContext appContext) : base(appContext)
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            if (!EnsureDatabaseAvailable()) return;
            LoadAllReports();
        }

        private void LoadAllReports()
        {
            LoadAvailableMedicines();
            LoadLowStockMedicines();
            LoadExpiredMedicines();
            LoadSalesHistory();
        }

        private void LoadAvailableMedicines()
        {
            try
            {
                dgvAvailable.DataSource = AppContext.InventoryService.GetAvailableMedicines()
                    .Select(m => new
                    {
                        m.Name,
                        m.Category,
                        Price = m.Price.ToString("F2"),
                        m.Quantity,
                        ExpiryDate = m.ExpiryDate.ToShortDateString()
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Failed to load available medicines report.");
            }
        }

        private void LoadLowStockMedicines()
        {
            try
            {
                dgvLowStock.DataSource = AppContext.InventoryService.CheckLowStock()
                    .Select(m => new
                    {
                        m.Name,
                        m.Category,
                        m.Quantity,
                        Price = m.Price.ToString("F2"),
                        ExpiryDate = m.ExpiryDate.ToShortDateString()
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Failed to load low stock report.");
            }
        }

        private void LoadExpiredMedicines()
        {
            try
            {
                dgvExpired.DataSource = AppContext.InventoryService.CheckExpiryDates()
                    .Select(m => new
                    {
                        m.Name,
                        m.Category,
                        m.Quantity,
                        ExpiryDate = m.ExpiryDate.ToShortDateString(),
                        Price = m.Price.ToString("F2")
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Failed to load expired medicines report.");
            }
        }

        private void LoadSalesHistory()
        {
            try
            {
                dgvSalesHistory.DataSource = AppContext.SaleService.GetAllSales()
                    .OrderByDescending(s => s.SaleDate)
                    .Select(s => new
                    {
                        s.CustomerName,
                        s.MedicineName,
                        s.Quantity,
                        Total = s.TotalAmount.ToString("F2"),
                        SaleDate = s.SaleDate.ToString("g")
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Failed to load sales history report.");
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
                case 0: LoadAvailableMedicines(); break;
                case 1: LoadLowStockMedicines(); break;
                case 2: LoadExpiredMedicines(); break;
                case 3: LoadSalesHistory(); break;
            }
        }
    }
}
