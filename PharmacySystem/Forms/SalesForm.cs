using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PharmacySystem.Core;
using PharmacySystem.Models;
using PharmacySystem.Utilities;

namespace PharmacySystem.Forms
{
    public partial class SalesForm : BaseForm
    {
        public SalesForm(PharmacyAppContext appContext) : base(appContext)
        {
            InitializeComponent();
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            if (!EnsureDatabaseAvailable()) return;

            LoadMedicines();
            RefreshSalesHistory();
            UpdatePriceDisplay();
        }

        private void LoadMedicines()
        {
            try
            {
                var medicines = AppContext.InventoryService.GetAvailableMedicines();
                cmbMedicine.DataSource = null;
                cmbMedicine.DataSource = medicines;
                cmbMedicine.DisplayMember = "Name";
                cmbMedicine.ValueMember = "Id";

                if (medicines.Count == 0)
                {
                    ShowWarning("No medicines available for sale. Add stock or check expiry dates.", "No Stock");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "Failed to load medicines.");
            }
        }

        private Medicine GetSelectedMedicine()
        {
            return cmbMedicine.SelectedItem as Medicine;
        }

        private void UpdatePriceDisplay()
        {
            var medicine = GetSelectedMedicine();
            lblPrice.Text = medicine != null ? $"${medicine.Price:F2}" : "$0.00";
            lblTotal.Text = $"${CalculateTotal():F2}";
        }

        private decimal CalculateTotal()
        {
            var medicine = GetSelectedMedicine();
            if (medicine == null)
            {
                return 0m;
            }

            return AppContext.SaleService.CalculateTotal(medicine.Price, (int)numSaleQuantity.Value);
        }

        private void RefreshSalesHistory()
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
                HandleException(ex, "Failed to load sales history.");
            }
        }

        private bool ValidateForm()
        {
            var medicine = GetSelectedMedicine();
            int availableStock = medicine?.Quantity ?? 0;

            if (cmbMedicine.SelectedItem == null)
            {
                errorProvider.SetError(cmbMedicine, "Please select a medicine.");
                return false;
            }

            var result = ValidationService.ValidateSale(
                txtCustomerName.Text,
                (int)numSaleQuantity.Value,
                availableStock);

            UiHelper.ApplyValidationErrors(errorProvider, result.Errors, new Dictionary<string, Control>
            {
                { "CustomerName", txtCustomerName },
                { "Quantity", numSaleQuantity }
            });

            if (!result.IsValid)
            {
                return false;
            }

            errorProvider.SetError(cmbMedicine, string.Empty);
            return true;
        }

        private void cmbMedicine_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePriceDisplay();
        }

        private void numSaleQuantity_ValueChanged(object sender, EventArgs e)
        {
            lblTotal.Text = $"${CalculateTotal():F2}";
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (cmbMedicine.SelectedItem == null)
            {
                ShowWarning("Please select a medicine first.", "Validation");
                return;
            }

            if (numSaleQuantity.Value <= 0)
            {
                ShowWarning("Quantity must be greater than zero.", "Validation");
                return;
            }

            decimal total = CalculateTotal();
            lblTotal.Text = $"${total:F2}";
            ShowSuccess($"Total Amount: ${total:F2}", "Calculation Result");
        }

        private void btnCompleteSale_Click(object sender, EventArgs e)
        {
            if (!EnsureDatabaseAvailable() || !ValidateForm()) return;

            var medicine = GetSelectedMedicine();
            if (medicine == null) return;

            if (!ConfirmAction(
                $"Complete sale of {numSaleQuantity.Value} x {medicine.Name} for ${CalculateTotal():F2}?",
                "Confirm Sale"))
            {
                return;
            }

            try
            {
                var sale = new Sale
                {
                    CustomerName = txtCustomerName.Text.Trim(),
                    Quantity = (int)numSaleQuantity.Value
                };

                AppContext.SaleService.ProcessSale(sale, medicine.Id);
                Logger.LogInfo($"Sale completed: {sale.Quantity} x {sale.MedicineName} for {sale.CustomerName}");

                ShowSuccess("Sale completed successfully!");
                ClearForm();
                LoadMedicines();
                RefreshSalesHistory();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Sale could not be completed.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtCustomerName.Clear();
            numSaleQuantity.Value = 1;
            lblTotal.Text = "$0.00";
            errorProvider.Clear();
            UpdatePriceDisplay();
        }
    }
}
