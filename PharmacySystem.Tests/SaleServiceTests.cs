using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PharmacySystem.Models;
using PharmacySystem.Services;

namespace PharmacySystem.Tests
{
    [TestClass]
    public class SaleServiceTests
    {
        private InMemoryMedicineRepository _medicineRepository;
        private InMemorySaleRepository _saleRepository;
        private SaleService _saleService;
        private string _medicineId;

        [TestInitialize]
        public void Setup()
        {
            _medicineRepository = new InMemoryMedicineRepository();
            _saleRepository = new InMemorySaleRepository();
            var inventoryService = new InventoryService(_medicineRepository);
            _saleService = new SaleService(_saleRepository, _medicineRepository, inventoryService);

            var medicine = new Medicine
            {
                Name = "Paracetamol",
                Category = "Analgesics",
                Price = 5.50m,
                Quantity = 20,
                ExpiryDate = DateTime.Today.AddYears(1)
            };
            _medicineRepository.Add(medicine);
            _medicineId = medicine.Id;
        }

        [TestMethod]
        public void CalculateTotal_ReturnsPriceTimesQuantity()
        {
            decimal total = _saleService.CalculateTotal(5.50m, 4);

            Assert.AreEqual(22.00m, total);
        }

        [TestMethod]
        public void ProcessSale_CompletesSaleAndReducesStock()
        {
            var sale = new Sale
            {
                CustomerName = "John Doe",
                Quantity = 5
            };

            _saleService.ProcessSale(sale, _medicineId);

            Assert.AreEqual(1, _saleService.GetAllSales().Count);
            Assert.AreEqual(27.50m, _saleService.GetAllSales()[0].TotalAmount);
            Assert.AreEqual(15, _medicineRepository.GetById(_medicineId).Quantity);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ProcessSale_ThrowsWhenStockInsufficient()
        {
            var sale = new Sale
            {
                CustomerName = "Jane Smith",
                Quantity = 100
            };

            _saleService.ProcessSale(sale, _medicineId);
        }
    }
}
