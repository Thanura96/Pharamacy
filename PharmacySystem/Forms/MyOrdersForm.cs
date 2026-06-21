using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PharmacySystem.Core;
using PharmacySystem.Models;
using PharmacySystem.Services;

namespace PharmacySystem.Forms
{
    public partial class MyOrdersForm : BaseForm
    {
        private readonly Customer _customer;
        private List<Order> _orders = new List<Order>();

        public MyOrdersForm(PharmacyAppContext appContext, Customer customer) : base(appContext)
        {
            InitializeComponent();
            _customer = customer;
        }

        private void MyOrdersForm_Load(object sender, EventArgs e)
        {
            if (EnsureDatabaseAvailable())
            {
                RefreshOrders();
            }
        }

        private void RefreshOrders()
        {
            try
            {
                _orders = AppContext.OrderRepository.GetOrdersByCustomer(_customer.Id);
                dgvOrders.DataSource = _orders.Select(o => new
                {
                    OrderNumber = o.OrderId,
                    OrderDate = o.OrderDate.ToString("g"),
                    Status = FormatStatus(o.OrderStatus),
                    TotalAmount = $"${o.TotalAmount:F2}"
                }).OrderByDescending(x => x.OrderDate).ToList();

                dgvOrders.ClearSelection();
                txtOrderDetails.Clear();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Failed to load orders.");
            }
        }

        private static string FormatStatus(OrderStatus status)
        {
            return PdfExportService.FormatStatus(status);
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0) return;

            try
            {
                string orderId = dgvOrders.SelectedRows[0].Cells["OrderNumber"].Value?.ToString();
                var order = AppContext.OrderRepository.GetOrderById(orderId);
                if (order == null) return;

                var lines = new List<string>
                {
                    $"Order Number: {order.OrderId}",
                    $"Order Date: {order.OrderDate:g}",
                    $"Status: {FormatStatus(order.OrderStatus)}",
                    $"Total Amount: ${order.TotalAmount:F2}",
                    $"Discount Applied: ${order.DiscountApplied:F2}",
                    "",
                    "Items:"
                };

                foreach (var item in order.Items)
                {
                    lines.Add($"  • {item.MedicineName} x {item.Quantity} @ ${item.UnitPrice:F2} = ${item.SubTotal:F2}");
                }

                if (!string.IsNullOrEmpty(order.PrescriptionPath))
                {
                    lines.Add("");
                    lines.Add($"Prescription: {order.PrescriptionPath}");
                }

                txtOrderDetails.Text = string.Join(Environment.NewLine, lines);
            }
            catch
            {
                // Ignore selection noise during grid rebinding.
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!EnsureDatabaseAvailable()) return;
            RefreshOrders();
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            ExportOrders(isPdf: true);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportOrders(isPdf: false);
        }

        private void ExportOrders(bool isPdf)
        {
            if (!EnsureDatabaseAvailable()) return;

            if (_orders.Count == 0)
            {
                ShowWarning("There are no orders to export.", "No Data");
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                if (isPdf)
                {
                    sfd.Filter = "PDF Files|*.pdf";
                    sfd.FileName = $"MyOrders_{_customer.Username}_{DateTime.Now:yyyyMMdd}.pdf";
                }
                else
                {
                    sfd.Filter = "Excel Files|*.xls";
                    sfd.FileName = $"MyOrders_{_customer.Username}_{DateTime.Now:yyyyMMdd}.xls";
                }

                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    string title = $"Order History - {_customer.FullName}";
                    if (isPdf)
                    {
                        AppContext.ExportService.ExportOrdersToPdf(_orders, sfd.FileName, title);
                    }
                    else
                    {
                        AppContext.ExportService.ExportOrdersToExcel(_orders, sfd.FileName);
                    }

                    Logger?.LogInfo($"Customer '{_customer.Username}' exported order history to {sfd.FileName}");
                    ShowSuccess("Order history exported successfully!", "Export Complete");
                }
                catch (Exception ex)
                {
                    HandleException(ex, "Failed to export order history.");
                }
            }
        }
    }
}
