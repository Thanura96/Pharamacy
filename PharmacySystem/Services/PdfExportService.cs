using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PharmacySystem.Models;

namespace PharmacySystem.Services
{
    public class PdfExportService
    {
        public void ExportOrders(IEnumerable<Order> orders, string filePath, string reportTitle)
        {
            if (orders == null)
            {
                throw new ArgumentNullException(nameof(orders));
            }

            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File path is required.", nameof(filePath));
            }

            var lines = new List<string> { reportTitle ?? "Customer Order History", "" };

            foreach (var order in orders)
            {
                lines.Add($"Order Number: {order.OrderId}");
                lines.Add($"Date: {order.OrderDate:g}");
                lines.Add($"Medicines: {FormatMedicines(order)}");
                lines.Add($"Total: ${order.TotalAmount:F2}");
                lines.Add($"Status: {FormatStatus(order.OrderStatus)}");
                lines.Add("");
            }

            WriteSimplePdf(filePath, lines);
        }

        internal static string FormatMedicines(Order order)
        {
            if (order.Items == null || order.Items.Count == 0)
            {
                return "None";
            }

            return string.Join(", ", order.Items.Select(i => $"{i.MedicineName} x{i.Quantity}"));
        }

        internal static string FormatStatus(OrderStatus status)
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

        private static void WriteSimplePdf(string filePath, IList<string> lines)
        {
            var content = new StringBuilder();
            content.AppendLine("BT");
            content.AppendLine("/F1 11 Tf");
            content.AppendLine("50 780 Td");
            content.AppendLine("14 TL");

            bool firstLine = true;
            foreach (var line in lines)
            {
                string safeLine = EscapePdfText(line ?? string.Empty);
                if (firstLine)
                {
                    content.AppendLine($"({safeLine}) Tj");
                    firstLine = false;
                }
                else
                {
                    content.AppendLine("T*");
                    content.AppendLine($"({safeLine}) Tj");
                }
            }

            content.AppendLine("ET");
            string stream = content.ToString();
            byte[] streamBytes = Encoding.UTF8.GetBytes(stream);

            using (var writer = new StreamWriter(filePath, false, Encoding.ASCII))
            {
                writer.WriteLine("%PDF-1.4");
                writer.WriteLine("1 0 obj << /Type /Catalog /Pages 2 0 R >> endobj");
                writer.WriteLine("2 0 obj << /Type /Pages /Kids [3 0 R] /Count 1 >> endobj");
                writer.WriteLine("3 0 obj << /Type /Page /Parent 2 0 R /MediaBox [0 0 612 792] /Contents 4 0 R /Resources << /Font << /F1 5 0 R >> >> >> endobj");
                writer.WriteLine($"4 0 obj << /Length {streamBytes.Length} >> stream");
                writer.Write(stream);
                writer.WriteLine("endstream endobj");
                writer.WriteLine("5 0 obj << /Type /Font /Subtype /Type1 /BaseFont /Helvetica >> endobj");
                writer.WriteLine("xref");
                writer.WriteLine("0 6");
                writer.WriteLine("0000000000 65535 f ");
                writer.WriteLine("0000000009 00000 n ");
                writer.WriteLine("0000000058 00000 n ");
                writer.WriteLine("0000000115 00000 n ");
                writer.WriteLine("0000000266 00000 n ");
                writer.WriteLine("0000000400 00000 n ");
                writer.WriteLine("trailer << /Size 6 /Root 1 0 R >>");
                writer.WriteLine("startxref");
                writer.WriteLine("480");
                writer.WriteLine("%%EOF");
            }
        }

        private static string EscapePdfText(string text)
        {
            return text
                .Replace("\\", "\\\\")
                .Replace("(", "\\(")
                .Replace(")", "\\)");
        }
    }
}
