using System.Collections.Generic;
using PharmacySystem.Models;
using PharmacySystem.Services.Interfaces;

namespace PharmacySystem.Services
{
    /// <summary>
    /// Facade export service demonstrating abstraction over concrete export implementations.
    /// </summary>
    public class ExportService : IExportService
    {
        private readonly PdfExportService _pdfExportService;
        private readonly ExcelExportService _excelExportService;

        public ExportService()
            : this(new PdfExportService(), new ExcelExportService())
        {
        }

        public ExportService(PdfExportService pdfExportService, ExcelExportService excelExportService)
        {
            _pdfExportService = pdfExportService;
            _excelExportService = excelExportService;
        }

        public void ExportOrdersToPdf(IEnumerable<Order> orders, string filePath, string reportTitle)
        {
            _pdfExportService.ExportOrders(orders, filePath, reportTitle);
        }

        public void ExportOrdersToExcel(IEnumerable<Order> orders, string filePath)
        {
            _excelExportService.ExportOrders(orders, filePath);
        }
    }
}
