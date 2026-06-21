using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PharmacySystem.Models;
using PharmacySystem.Services;

namespace PharmacySystem.Tests
{
    [TestClass]
    public class ExportServiceTests
    {
        private string _tempDirectory;

        [TestInitialize]
        public void Setup()
        {
            _tempDirectory = Path.Combine(Path.GetTempPath(), "PharmacyExportTests_" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(_tempDirectory);
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (Directory.Exists(_tempDirectory))
            {
                Directory.Delete(_tempDirectory, true);
            }
        }

        [TestMethod]
        public void ExportService_CreatesPdfAndExcelFiles()
        {
            var orders = new List<Order>
            {
                new Order
                {
                    OrderId = "order1",
                    OrderDate = DateTime.Today,
                    TotalAmount = 25.50m,
                    OrderStatus = OrderStatus.Pending,
                    Items = new List<OrderItem>
                    {
                        new OrderItem { MedicineName = "Paracetamol", Quantity = 2, UnitPrice = 5m, SubTotal = 10m }
                    }
                }
            };

            var exportService = new ExportService();
            string pdfPath = Path.Combine(_tempDirectory, "orders.pdf");
            string excelPath = Path.Combine(_tempDirectory, "orders.xls");

            exportService.ExportOrdersToPdf(orders, pdfPath, "Test Orders");
            exportService.ExportOrdersToExcel(orders, excelPath);

            Assert.IsTrue(File.Exists(pdfPath));
            Assert.IsTrue(File.Exists(excelPath));
            Assert.IsTrue(new FileInfo(pdfPath).Length > 0);
            Assert.IsTrue(new FileInfo(excelPath).Length > 0);
        }
    }
}
