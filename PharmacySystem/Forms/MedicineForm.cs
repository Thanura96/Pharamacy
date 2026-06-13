using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PharmacySystem.Core;
using PharmacySystem.Models;
using PharmacySystem.Utilities;

namespace PharmacySystem.Forms
{
    public partial class MedicineForm : BaseForm
    {
        private string _selectedMedicineId;

        public MedicineForm(PharmacyAppContext appContext) : base(appContext)
        {
            InitializeComponent();
        }

        private void MedicineForm_Load(object sender, EventArgs e)
        {
            if (!EnsureDatabaseAvailable()) return;
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            try
            {
                dgvMedicines.DataSource = AppContext.MedicineService.GetAllMedicines()
                    .Select(m => new
                    {
                        m.Id,
                        m.Name,
                        m.Category,
                        Price = m.Price.ToString("F2"),
                        m.Quantity,
                        ExpiryDate = m.ExpiryDate.ToShortDateString()
                    }).ToList();
                dgvMedicines.ClearSelection();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Failed to load medicine list.");
            }
        }

        private bool ValidateForm()
        {
            var result = ValidationService.ValidateMedicine(
                txtName.Text,
                txtCategory.Text,
                txtPrice.Text,
                (int)numQuantity.Value,
                dtpExpiryDate.Value.Date);

            UiHelper.ApplyValidationErrors(errorProvider, result.Errors, new Dictionary<string, Control>
            {
                { "Name", txtName },
                { "Category", txtCategory },
                { "Price", txtPrice },
                { "Quantity", numQuantity },
                { "ExpiryDate", dtpExpiryDate }
            });

            return result.IsValid;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!EnsureDatabaseAvailable() || !ValidateForm()) return;

            try
            {
                var medicine = new Medicine
                {
                    Name = txtName.Text.Trim(),
                    Category = txtCategory.Text.Trim(),
                    Price = decimal.Parse(txtPrice.Text),
                    Quantity = (int)numQuantity.Value,
                    ExpiryDate = dtpExpiryDate.Value.Date
                };

                AppContext.MedicineService.AddMedicine(medicine);
                Logger.LogInfo($"Medicine added: {medicine.Name}");
                ShowSuccess("Medicine successfully added!");
                ClearForm();
                RefreshGrid();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error adding medicine.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedMedicineId))
            {
                ShowWarning("Please select a medicine record from the grid first.", "Selection Required");
                return;
            }

            if (!EnsureDatabaseAvailable() || !ValidateForm()) return;

            try
            {
                var existingMed = AppContext.MedicineService.GetMedicineById(_selectedMedicineId);
                if (existingMed == null)
                {
                    ShowWarning("Selected medicine could not be found.", "Not Found");
                    return;
                }

                existingMed.Name = txtName.Text.Trim();
                existingMed.Category = txtCategory.Text.Trim();
                existingMed.Price = decimal.Parse(txtPrice.Text);
                existingMed.Quantity = (int)numQuantity.Value;
                existingMed.ExpiryDate = dtpExpiryDate.Value.Date;

                AppContext.MedicineService.UpdateMedicine(existingMed);
                Logger.LogInfo($"Medicine updated: {existingMed.Name}");
                ShowSuccess("Medicine successfully updated!");
                ClearForm();
                RefreshGrid();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error updating medicine.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedMedicineId))
            {
                ShowWarning("Please select a medicine record to delete.", "Selection Required");
                return;
            }

            if (!EnsureDatabaseAvailable()) return;

            if (!ConfirmAction("Are you sure you want to delete this medicine record?", "Confirm Delete"))
            {
                return;
            }

            try
            {
                AppContext.MedicineService.DeleteMedicine(_selectedMedicineId);
                Logger.LogInfo($"Medicine deleted: {_selectedMedicineId}");
                ShowSuccess("Medicine record deleted.", "Deleted");
                ClearForm();
                RefreshGrid();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error deleting medicine.");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!EnsureDatabaseAvailable()) return;

            string searchName = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchName))
            {
                ShowWarning("Please enter a medicine name to search.", "Input Required");
                return;
            }

            try
            {
                var results = AppContext.MedicineService.SearchMedicines(searchName)
                    .Select(m => new
                    {
                        m.Id,
                        m.Name,
                        m.Category,
                        Price = m.Price.ToString("F2"),
                        m.Quantity,
                        ExpiryDate = m.ExpiryDate.ToShortDateString()
                    }).ToList();

                dgvMedicines.DataSource = results;
                if (results.Count == 0)
                {
                    ShowWarning("No medicines found matching the search criteria.", "No Results");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error performing search.");
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            RefreshGrid();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            _selectedMedicineId = null;
            txtName.Clear();
            txtCategory.Clear();
            txtPrice.Clear();
            numQuantity.Value = 0;
            dtpExpiryDate.Value = DateTime.Today.AddDays(1);
            errorProvider.Clear();
            dgvMedicines.ClearSelection();
        }

        private void dgvMedicines_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMedicines.SelectedRows.Count == 0) return;

            try
            {
                var row = dgvMedicines.SelectedRows[0];
                _selectedMedicineId = row.Cells["Id"].Value?.ToString();
                txtName.Text = row.Cells["Name"].Value?.ToString();
                txtCategory.Text = row.Cells["Category"].Value?.ToString();
                txtPrice.Text = row.Cells["Price"].Value?.ToString();

                if (int.TryParse(row.Cells["Quantity"].Value?.ToString(), out int qty))
                {
                    numQuantity.Value = qty;
                }

                if (DateTime.TryParse(row.Cells["ExpiryDate"].Value?.ToString(), out DateTime date))
                {
                    dtpExpiryDate.Value = date;
                }
            }
            catch
            {
                // Ignore selection errors during grid rebinding.
            }
        }
    }
}
