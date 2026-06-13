using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PharmacySystem.Models;
using PharmacySystem.Services;

namespace PharmacySystem.Tests
{
    [TestClass]
    public class InventoryServiceTests
    {
        private InMemoryMedicineRepository _repository;
        private InventoryService _service;

        [TestInitialize]
        public void Setup()
        {
            _repository = new InMemoryMedicineRepository();
            _service = new InventoryService(_repository);
        }

        [TestMethod]
        public void CheckLowStock_ReturnsMedicinesBelowThreshold()
        {
            _repository.Add(new Medicine
            {
                Name = "Vitamin C",
                Category = "Supplements",
                Price = 8.75m,
                Quantity = 8,
                ExpiryDate = DateTime.Today.AddYears(1)
            });
            _repository.Add(new Medicine
            {
                Name = "Paracetamol",
                Category = "Analgesics",
                Price = 5.50m,
                Quantity = 50,
                ExpiryDate = DateTime.Today.AddYears(1)
            });

            var lowStock = _service.CheckLowStock();

            Assert.AreEqual(1, lowStock.Count);
            Assert.AreEqual("Vitamin C", lowStock[0].Name);
        }

        [TestMethod]
        public void CheckExpiryDates_ReturnsExpiredMedicines()
        {
            _repository.Add(new Medicine
            {
                Name = "Expired Drug",
                Category = "General",
                Price = 4.00m,
                Quantity = 10,
                ExpiryDate = DateTime.Today.AddDays(-1)
            });

            var expired = _service.CheckExpiryDates();

            Assert.AreEqual(1, expired.Count);
            Assert.AreEqual("Expired Drug", expired[0].Name);
        }

        [TestMethod]
        public void UpdateStock_ReducesQuantityAfterSale()
        {
            var medicine = new Medicine
            {
                Name = "Amoxicillin",
                Category = "Antibiotics",
                Price = 12.00m,
                Quantity = 20,
                ExpiryDate = DateTime.Today.AddYears(1)
            };
            _repository.Add(medicine);

            _service.UpdateStock(medicine.Id, 3);

            Assert.AreEqual(17, _repository.GetById(medicine.Id).Quantity);
        }
    }
}
