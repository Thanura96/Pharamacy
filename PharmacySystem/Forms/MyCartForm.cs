using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PharmacySystem.Core;
using PharmacySystem.Models;
using PharmacySystem.Services.Interfaces;

namespace PharmacySystem.Forms
{
    public partial class MyCartForm : BaseForm
    {
        private readonly ICartService _cartService;
        private readonly Customer _customer;

        public MyCartForm(PharmacyAppContext appContext, ICartService cartService, Customer customer)
            : base(appContext)
        {
            InitializeComponent();
            _cartService = cartService;
            _customer = customer;
        }

        private void MyCartForm_Load(object sender, EventArgs e)
        {
            RefreshCart();
        }

        private void RefreshCart()
        {
            dgvCart.DataSource = _cartService.Items.Select(item => new
            {
                item.MedicineId,
                item.MedicineName,
                item.Quantity,
                Price = $"${item.UnitPrice:F2}",
                SubTotal = $"${item.SubTotal:F2}"
            }).ToList();

            decimal total = _cartService.CalculateTotal();
            decimal discount = _cartService.CalculateDiscount();

            lblTotal.Text = $"Total Amount: ${total:F2}";
            lblDiscount.Text = $"Discounts Applied: ${discount:F2}";

            bool rxRequired = _cartService.RequiresPrescription();
            lblRxWarning.Visible = rxRequired;
            txtPrescriptionPath.Enabled = rxRequired;
            btnBrowsePrescription.Enabled = rxRequired;
            if (!rxRequired)
            {
                txtPrescriptionPath.Clear();
            }

            dgvCart.ClearSelection();
        }

        private void dgvCart_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count == 0) return;

            if (int.TryParse(dgvCart.SelectedRows[0].Cells["Quantity"].Value?.ToString(), out int qty))
            {
                numQuantity.Value = Math.Max(numQuantity.Minimum, Math.Min(numQuantity.Maximum, qty));
            }
        }

        private void btnUpdateQuantity_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count == 0)
            {
                ShowWarning("Please select a cart item first.", "Selection Required");
                return;
            }

            string medId = dgvCart.SelectedRows[0].Cells["MedicineId"].Value?.ToString();
            int qty = (int)numQuantity.Value;

            if (!_cartService.UpdateQuantity(medId, qty, out string error))
            {
                ShowWarning(error, "Update Failed");
                return;
            }

            RefreshCart();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count == 0)
            {
                ShowWarning("Please select a cart item to remove.", "Selection Required");
                return;
            }

            string medId = dgvCart.SelectedRows[0].Cells["MedicineId"].Value?.ToString();
            _cartService.RemoveFromCart(medId);
            RefreshCart();
        }

        private void btnBrowsePrescription_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Prescription Files|*.pdf;*.jpg;*.jpeg;*.png|PDF Files|*.pdf|Image Files|*.jpg;*.jpeg;*.png";
                ofd.Title = "Upload Prescription";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtPrescriptionPath.Text = ofd.FileName;
                }
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (!EnsureDatabaseAvailable()) return;

            var medicinesById = BuildMedicineLookup();
            var validation = ValidationService.ValidateOrder(
                _cartService.Items,
                _cartService.RequiresPrescription(),
                txtPrescriptionPath.Text.Trim(),
                medicinesById);

            if (!validation.IsValid)
            {
                ShowWarning(validation.GetFirstError(), "Order Validation");
                return;
            }

            decimal total = _cartService.CalculateTotal();
            if (!ConfirmAction($"Complete checkout for a total of ${total:F2}?", "Confirm Checkout"))
            {
                return;
            }

            try
            {
                var order = new Order
                {
                    CustomerId = _customer.Id,
                    CustomerName = _customer.FullName,
                    OrderDate = DateTime.Now,
                    TotalAmount = total,
                    OrderStatus = OrderStatus.Pending,
                    PrescriptionPath = txtPrescriptionPath.Text.Trim(),
                    DiscountApplied = _cartService.CalculateDiscount(),
                    Items = _cartService.ToOrderItems()
                };

                AppContext.OrderRepository.AddOrder(order);

                foreach (var cartItem in _cartService.Items)
                {
                    var med = AppContext.MedicineService.GetMedicineById(cartItem.MedicineId);
                    if (med != null)
                    {
                        med.Quantity -= cartItem.Quantity;
                        AppContext.MedicineService.UpdateMedicine(med);
                    }
                }

                Logger?.LogInfo($"Customer '{_customer.Username}' placed order {order.OrderId} for ${total:F2}");
                ShowSuccess("Order placed successfully!", "Checkout Complete");

                _cartService.Clear();
                txtPrescriptionPath.Clear();
                RefreshCart();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Checkout failed.");
            }
        }

        private Dictionary<string, Medicine> BuildMedicineLookup()
        {
            var lookup = new Dictionary<string, Medicine>();
            foreach (var item in _cartService.Items)
            {
                if (!lookup.ContainsKey(item.MedicineId))
                {
                    lookup[item.MedicineId] = AppContext.MedicineService.GetMedicineById(item.MedicineId);
                }
            }
            return lookup;
        }
    }
}
