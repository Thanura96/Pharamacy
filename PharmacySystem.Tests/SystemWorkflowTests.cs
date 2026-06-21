using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PharmacySystem.Models;
using PharmacySystem.Services;

namespace PharmacySystem.Tests
{
    /// <summary>
    /// Scenario-based tests covering admin and customer workflows at the service layer.
    /// </summary>
    [TestClass]
    public class SystemWorkflowTests
    {
        [TestMethod]
        public void AdminScenario_LoginValidation_AcceptsAdminCredentialsFormat()
        {
            var validation = new ValidationService().ValidateLogin("admin", "admin123");
            Assert.IsTrue(validation.IsValid);
        }

        [TestMethod]
        public void AdminScenario_MedicineManagement_ValidatesRequiredMedicineFields()
        {
            var validation = new ValidationService().ValidateMedicine(
                "Ibuprofen", "Analgesics", "8.00", 20, DateTime.Today.AddYears(1), "10", "200mg", "MedSupply");

            Assert.IsTrue(validation.IsValid);
        }

        [TestMethod]
        public void AdminScenario_CustomerManagement_ValidatesUniqueUsernameRule()
        {
            var validation = new ValidationService().ValidateCustomer(
                "Jane Smith", "5550144", "45 Oak Ave", "jane@example.com", "janesmith", "pass123", true);

            Assert.IsFalse(validation.IsValid);
        }

        [TestMethod]
        public void CustomerScenario_Registration_ValidatesEmailAndPhone()
        {
            var validation = new ValidationService().ValidateRegistration(
                "New User", "1 Main St", "newuser@example.com", "5550100", "newuser", "pass123", "pass123", false);

            Assert.IsTrue(validation.IsValid);
        }

        [TestMethod]
        public void CustomerScenario_CartAndOrder_RequiresPrescriptionWhenNeeded()
        {
            var medicineService = new MedicineService(new InMemoryMedicineRepository());
            medicineService.AddMedicine(new Medicine
            {
                Name = "Amoxicillin",
                Category = "Antibiotics",
                Price = 12m,
                Quantity = 10,
                ExpiryDate = DateTime.Today.AddYears(1),
                Dosage = "250mg",
                Supplier = "MedSupply",
                RequiresPrescription = true
            });

            var medicines = medicineService.GetAllMedicines();
            var cartService = new CartService(medicineService);
            cartService.AddToCart(medicines[0], 1, out _);

            var orderValidation = new ValidationService().ValidateOrder(
                cartService.Items,
                cartService.RequiresPrescription(),
                "",
                new Dictionary<string, Medicine> { { medicines[0].Id, medicines[0] } });

            Assert.IsFalse(orderValidation.IsValid);
        }

        [TestMethod]
        public void CustomerScenario_SearchMedicines_FiltersByNameUsingLinearSearch()
        {
            var repo = new InMemoryMedicineRepository();
            repo.Add(new Medicine
            {
                Name = "Paracetamol",
                Category = "Analgesics",
                Price = 5m,
                Quantity = 10,
                ExpiryDate = DateTime.Today.AddYears(1)
            });
            repo.Add(new Medicine
            {
                Name = "Vitamin C",
                Category = "Supplements",
                Price = 8m,
                Quantity = 10,
                ExpiryDate = DateTime.Today.AddYears(1)
            });

            var searchService = new MedicineSearchService();
            var results = searchService.Search(repo.GetAll(), "para", null, null, null);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Paracetamol", results[0].Name);
        }

        [TestMethod]
        public void NotificationScenario_ExpiryService_DetectsExpiringAndExpiredMedicines()
        {
            var repo = new InMemoryMedicineRepository();
            repo.Add(new Medicine
            {
                Name = "Soon Expiring",
                Category = "Test",
                Price = 1m,
                Quantity = 5,
                ExpiryDate = DateTime.Today.AddDays(10)
            });
            repo.Add(new Medicine
            {
                Name = "Already Expired",
                Category = "Test",
                Price = 1m,
                Quantity = 5,
                ExpiryDate = DateTime.Today.AddDays(-2)
            });

            var notificationService = new ExpiryNotificationService(repo);

            Assert.AreEqual(1, notificationService.GetExpiringWithinDays(30).Count);
            Assert.AreEqual(1, notificationService.GetExpiredMedicines().Count);
        }
    }
}
