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
        private string _selectedCustomerId;

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
                    .Select(c => new
                    {
                        c.Id,
                        c.Name,
                        c.Phone,
                        c.Email,
                        c.Address,
                        c.Username
                    }).ToList();
                dgvCustomers.ClearSelection();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Failed to load customer list.");
            }
        }

        private bool ValidateFormForAdd()
        {
            bool isDuplicate = false;
            try
            {
                var username = txtUsername.Text.Trim();
                isDuplicate = AppContext.CustomerService.GetAllCustomers()
                    .Any(c => !string.IsNullOrEmpty(c.Username) &&
                              c.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error checking duplicate username.");
                return false;
            }

            var result = ValidationService.ValidateCustomer(
                txtCustomerName.Text,
                txtPhone.Text,
                txtAddress.Text,
                txtEmail.Text,
                txtUsername.Text,
                txtPassword.Text,
                isDuplicate);

            UiHelper.ApplyValidationErrors(errorProvider, result.Errors, new Dictionary<string, Control>
            {
                { "Name", txtCustomerName },
                { "Phone", txtPhone },
                { "Address", txtAddress },
                { "Email", txtEmail },
                { "Username", txtUsername },
                { "Password", txtPassword }
            });

            return result.IsValid;
        }

        private bool ValidateFormForUpdate()
        {
            var result = ValidationService.ValidateCustomerUpdate(
                txtCustomerName.Text,
                txtPhone.Text,
                txtAddress.Text,
                txtEmail.Text);

            UiHelper.ApplyValidationErrors(errorProvider, result.Errors, new Dictionary<string, Control>
            {
                { "Name", txtCustomerName },
                { "Phone", txtPhone },
                { "Address", txtAddress },
                { "Email", txtEmail }
            });

            return result.IsValid;
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (!EnsureDatabaseAvailable() || !ValidateFormForAdd()) return;

            try
            {
                var customer = new Customer
                {
                    FullName = txtCustomerName.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text
                };

                AppContext.CustomerService.AddCustomer(customer);
                Logger.LogInfo($"Customer added: {customer.FullName}");
                ShowSuccess("Customer registered successfully!");
                ClearForm();
                RefreshGrid();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error adding customer.");
            }
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedCustomerId))
            {
                ShowWarning("Please select a customer from the list to update.", "Selection Required");
                return;
            }

            if (!EnsureDatabaseAvailable() || !ValidateFormForUpdate()) return;

            try
            {
                var existing = AppContext.CustomerService.GetCustomerById(_selectedCustomerId);
                if (existing == null)
                {
                    ShowWarning("Selected customer could not be found.", "Not Found");
                    return;
                }

                existing.FullName = txtCustomerName.Text.Trim();
                existing.Phone = txtPhone.Text.Trim();
                existing.Address = txtAddress.Text.Trim();
                existing.Email = txtEmail.Text.Trim();

                if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    existing.Password = txtPassword.Text;
                }

                if (!string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    bool duplicate = AppContext.CustomerService.GetAllCustomers()
                        .Any(c => c.Id != _selectedCustomerId &&
                                  !string.IsNullOrEmpty(c.Username) &&
                                  c.Username.Equals(txtUsername.Text.Trim(), StringComparison.OrdinalIgnoreCase));
                    if (duplicate)
                    {
                        ShowWarning("Username is already taken by another customer.", "Validation");
                        return;
                    }
                    existing.Username = txtUsername.Text.Trim();
                }

                AppContext.CustomerService.UpdateCustomer(existing);
                Logger.LogInfo($"Customer updated: {existing.FullName}");
                ShowSuccess("Customer information updated successfully!");
                ClearForm();
                RefreshGrid();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error updating customer.");
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
                    .Select(c => new
                    {
                        c.Id,
                        c.Name,
                        c.Phone,
                        c.Email,
                        c.Address,
                        c.Username
                    }).ToList();

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
            _selectedCustomerId = null;
            txtCustomerName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            errorProvider.Clear();
            dgvCustomers.ClearSelection();
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0) return;

            var row = dgvCustomers.SelectedRows[0];
            _selectedCustomerId = row.Cells["Id"].Value?.ToString();
            txtCustomerName.Text = row.Cells["Name"].Value?.ToString();
            txtPhone.Text = row.Cells["Phone"].Value?.ToString();
            txtAddress.Text = row.Cells["Address"].Value?.ToString() ?? string.Empty;
            txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? string.Empty;
            txtUsername.Text = row.Cells["Username"].Value?.ToString() ?? string.Empty;
            txtPassword.Clear();
        }
    }
}
