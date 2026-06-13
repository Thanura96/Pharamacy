using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PharmacySystem.Core;
using PharmacySystem.Models;
using PharmacySystem.Utilities;

namespace PharmacySystem.Forms
{
    public partial class CustomerForm : BaseForm
    {
        public CustomerForm(PharmacyAppContext appContext) : base(appContext)
        {
            InitializeComponent();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            if (!EnsureDatabaseAvailable()) return;
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            try
            {
                dgvCustomers.DataSource = AppContext.CustomerService.GetAllCustomers()
                    .Select(c => new { c.Id, c.Name, c.Phone })
                    .ToList();
                dgvCustomers.ClearSelection();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Failed to load customer list.");
            }
        }

        private bool ValidateForm()
        {
            var result = ValidationService.ValidateCustomer(txtCustomerName.Text, txtPhone.Text);

            UiHelper.ApplyValidationErrors(errorProvider, result.Errors, new Dictionary<string, Control>
            {
                { "Name", txtCustomerName },
                { "Phone", txtPhone }
            });

            return result.IsValid;
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (!EnsureDatabaseAvailable() || !ValidateForm()) return;

            try
            {
                var customer = new Customer
                {
                    Name = txtCustomerName.Text.Trim(),
                    Phone = txtPhone.Text.Trim()
                };

                AppContext.CustomerService.AddCustomer(customer);
                Logger.LogInfo($"Customer added: {customer.Name}");
                ShowSuccess("Customer registered successfully!");
                ClearForm();
                RefreshGrid();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error adding customer.");
            }
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            if (!EnsureDatabaseAvailable()) return;

            string searchName = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchName))
            {
                ShowWarning("Please enter a customer name to search.", "Input Required");
                return;
            }

            try
            {
                var results = AppContext.CustomerService.SearchCustomers(searchName)
                    .Select(c => new { c.Id, c.Name, c.Phone })
                    .ToList();

                dgvCustomers.DataSource = results;
                if (results.Count == 0)
                {
                    ShowWarning("No customers found matching the search query.", "No Results");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "Search failed.");
            }
        }

        private void btnViewCustomers_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            RefreshGrid();
        }

        private void btnClearCustomer_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtCustomerName.Clear();
            txtPhone.Clear();
            errorProvider.Clear();
            dgvCustomers.ClearSelection();
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0) return;

            var row = dgvCustomers.SelectedRows[0];
            txtCustomerName.Text = row.Cells["Name"].Value?.ToString();
            txtPhone.Text = row.Cells["Phone"].Value?.ToString();
        }
    }
}
