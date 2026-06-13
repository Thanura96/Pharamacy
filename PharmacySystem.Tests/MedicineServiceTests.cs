using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PharmacySystem.Models;
using PharmacySystem.Services;

namespace PharmacySystem.Tests
{
    [TestClass]
    public class MedicineServiceTests
    {
        private MedicineService _service;
        private InMemoryMedicineRepository _repository;

        [TestInitialize]
        public void Setup()
        {
            _repository = new InMemoryMedicineRepository();
            _service = new MedicineService(_repository);
        }

        [TestMethod]
        public void AddMedicine_AddsRecordSuccessfully()
        {
            var medicine = CreateMedicine("Paracetamol");

            _service.AddMedicine(medicine);

            Assert.AreEqual(1, _service.GetAllMedicines().Count);
            Assert.AreEqual("Paracetamol", _service.GetAllMedicines()[0].Name);
        }

        [TestMethod]
        public void UpdateMedicine_UpdatesExistingRecord()
        {
            var medicine = CreateMedicine("Amoxicillin");
            _service.AddMedicine(medicine);
            medicine = _service.GetAllMedicines()[0];
            medicine.Price = 15.00m;

            _service.UpdateMedicine(medicine);

            Assert.AreEqual(15.00m, _service.GetMedicineById(medicine.Id).Price);
        }

        [TestMethod]
        public void DeleteMedicine_RemovesRecord()
        {
            var medicine = CreateMedicine("Vitamin C");
            _service.AddMedicine(medicine);
            string id = _service.GetAllMedicines()[0].Id;

            _service.DeleteMedicine(id);

            Assert.AreEqual(0, _service.GetAllMedicines().Count);
        }

        [TestMethod]
        public void SearchMedicines_ReturnsMatchingRecords()
        {
            _service.AddMedicine(CreateMedicine("Paracetamol"));
            _service.AddMedicine(CreateMedicine("Amoxicillin"));

            var results = _service.SearchMedicines("para");

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Paracetamol", results[0].Name);
        }

        private static Medicine CreateMedicine(string name)
        {
            return new Medicine
            {
                Name = name,
                Category = "General",
                Price = 10m,
                Quantity = 20,
                ExpiryDate = DateTime.Today.AddYears(1)
            };
        }
    }
}
