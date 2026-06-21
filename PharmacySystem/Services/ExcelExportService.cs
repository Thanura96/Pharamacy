using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PharmacySystem.Models;

namespace PharmacySystem.Services
{
    public class ExcelExportService
    {
        public void ExportOrders(IEnumerable<Order> orders, string filePath)
        {
            if (orders == null)
            {
                throw new ArgumentNullException(nameof(orders));
            }

            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File path is required.", nameof(filePath));
            }

            var sb = new StringBuilder();
            sb.AppendLine("<html><head><meta charset=\"utf-8\"></head><body>");
            sb.AppendLine("<table border=\"1\" cellspacing=\"0\" cellpadding=\"4\">");
            sb.AppendLine("<tr><th>Order Number</th><th>Date</th><th>Medicines</th><th>Total</th><th>Status</th></tr>");

            foreach (var order in orders)
            {
                sb.AppendLine("<tr>");
                sb.AppendLine($"<td>{EscapeHtml(order.OrderId)}</td>");
                sb.AppendLine($"<td>{EscapeHtml(order.OrderDate.ToString("g"))}</td>");
                sb.AppendLine($"<td>{EscapeHtml(PdfExportService.FormatMedicines(order))}</td>");
                sb.AppendLine($"<td>${order.TotalAmount:F2}</td>");
                sb.AppendLine($"<td>{EscapeHtml(PdfExportService.FormatStatus(order.OrderStatus))}</td>");
                sb.AppendLine("</tr>");
            }

            sb.AppendLine("</table></body></html>");
            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        private static string EscapeHtml(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            return value
                .Replace("&", "&amp;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("\"", "&quot;");
        }
    }
}
