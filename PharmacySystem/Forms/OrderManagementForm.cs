using System;
using System.Linq;
using System.Windows.Forms;
using PharmacySystem.Core;
using PharmacySystem.Models;

namespace PharmacySystem.Forms
{
    public partial class OrderManagementForm : BaseForm
    {
        private string _selectedOrderId;

        public OrderManagementForm(PharmacyAppContext appContext) : base(appContext)
        {
            InitializeComponent();
        }

        private void OrderManagementForm_Load(object sender, EventArgs e)
        {
            if (!EnsureDatabaseAvailable()) return;

            cmbUpdateStatus.DataSource = Enum.GetValues(typeof(OrderStatus));
            RefreshOrdersGrid();
        }

        private void RefreshOrdersGrid()
        {
            try
            {
                var orders = AppContext.OrderRepository.GetAllOrders();
                dgvOrders.DataSource = orders.Select(o => new
                {
                    o.OrderId,
                    o.CustomerName,
                    OrderDate = o.OrderDate.ToString("g"),
                    TotalAmount = $"${o.TotalAmount:F2}",
                    Discount = $"${o.DiscountApplied:F2}",
                    Status = FormatStatus(o.OrderStatus),
                    HasPrescription = !string.IsNullOrEmpty(o.PrescriptionPath) ? "Yes" : "No"
                }).ToList();

                dgvOrders.ClearSelection();
                ClearDetails();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Failed to load orders list.");
            }
        }

        private static string FormatStatus(OrderStatus status)
        {
            switch (status)
            {
                case OrderStatus.ReadyForPickup:
                    return "Ready For Pickup";
                case OrderStatus.Delivered:
                    return "Delivered";
                default:
                    return "Pending";
            }
        }

        private void ClearDetails()
        {
            _selectedOrderId = null;
            lblSelectedOrder.Text = "None";
            txtOrderItems.Clear();
            txtPrescriptionPath.Clear();
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0) return;

            try
            {
                var row = dgvOrders.SelectedRows[0];
                _selectedOrderId = row.Cells["OrderId"].Value?.ToString();
                lblSelectedOrder.Text = $"Order ID: {_selectedOrderId}";

                var order = AppContext.OrderRepository.GetOrderById(_selectedOrderId);
                if (order != null)
                {
                    cmbUpdateStatus.SelectedItem = order.OrderStatus;
                    txtPrescriptionPath.Text = order.PrescriptionPath ?? "No prescription required/provided.";

                    var itemsText = string.Join(Environment.NewLine, order.Items.Select(
                        item => $"{item.MedicineName} x {item.Quantity} @ ${item.UnitPrice:F2} (Subtotal: ${item.SubTotal:F2})"));
                    txtOrderItems.Text = itemsText;
                }
            }
            catch
            {
                // Ignore selection binder noise
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedOrderId))
            {
                ShowWarning("Please select an order from the list first.", "Selection Required");
                return;
            }

            try
            {
                var status = (OrderStatus)cmbUpdateStatus.SelectedItem;
                AppContext.OrderRepository.UpdateOrderStatus(_selectedOrderId, status);
                Logger?.LogInfo($"Order {_selectedOrderId} status updated to {status}");
                ShowSuccess("Order status saved to database successfully!");
                RefreshOrdersGrid();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Failed to update order status.");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshOrdersGrid();
        }

        private void btnViewPrescription_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrescriptionPath.Text) || txtPrescriptionPath.Text.Contains("No prescription"))
            {
                ShowWarning("No prescription file is associated with this order.", "Unavailable");
                return;
            }

            ShowSuccess($"Prescription Path:\n{txtPrescriptionPath.Text}", "Prescription File");
        }
    }
}
