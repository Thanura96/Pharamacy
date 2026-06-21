using System.Collections.Generic;
using PharmacySystem.Models;

namespace PharmacySystem.Services.Interfaces
{
    public interface IExportService
    {
        void ExportOrdersToPdf(IEnumerable<Order> orders, string filePath, string reportTitle);
        void ExportOrdersToExcel(IEnumerable<Order> orders, string filePath);
    }
}
