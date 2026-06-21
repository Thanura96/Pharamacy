using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PharmacySystem.Models;
using PharmacySystem.Services;

namespace PharmacySystem.Tests
{
    [TestClass]
    public class ValidationServiceTests
    {
        private ValidationService _service;

        [TestInitialize]
        public void Setup()
        {
            _service = new ValidationService();
        }

        [TestMethod]
        public void ValidateMedicine_FailsWhenRequiredFieldsMissing()
        {
            var result = _service.ValidateMedicine("", "", "0", -1, DateTime.Today, "0", "", "");

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.ContainsKey("Dosage"));
            Assert.IsTrue(result.Errors.ContainsKey("Supplier"));
        }

        [TestMethod]
        public void ValidateMedicine_SucceedsForValidData()
        {
            var result = _service.ValidateMedicine(
                "Paracetamol", "Analgesics", "5.50", 10, DateTime.Today.AddYears(1), "5", "500mg", "PharmaCorp");

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void ValidateCustomer_FailsWhenPhoneInvalid()
        {
            var result = _service.ValidateCustomer("John Doe", "", "123 Main St", "john@example.com", "johndoe", "pass123", false);

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void ValidateSale_FailsWhenStockInsufficient()
        {
            var result = _service.ValidateSale("John Doe", 20, 5);

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void ValidateOrder_FailsWhenPrescriptionRequiredButMissing()
        {
            var items = new List<CartItem>
            {
                new CartItem { MedicineId = "1", MedicineName = "Amoxicillin", Quantity = 1, UnitPrice = 10m, SubTotal = 10m }
            };

            var medicines = new Dictionary<string, Medicine>
            {
                {
                    "1",
                    new Medicine { Id = "1", Name = "Amoxicillin", Quantity = 5, RequiresPrescription = true }
                }
            };

            var result = _service.ValidateOrder(items, true, "", medicines);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.ContainsKey("Prescription"));
        }

        [TestMethod]
        public void ValidateOrder_FailsWhenStockUnavailable()
        {
            var items = new List<CartItem>
            {
                new CartItem { MedicineId = "1", MedicineName = "Vitamin C", Quantity = 10, UnitPrice = 5m, SubTotal = 50m }
            };

            var medicines = new Dictionary<string, Medicine>
            {
                { "1", new Medicine { Id = "1", Name = "Vitamin C", Quantity = 2, RequiresPrescription = false } }
            };

            var result = _service.ValidateOrder(items, false, "", medicines);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.ContainsKey("Quantity"));
        }

        [TestMethod]
        public void ValidateRegistration_SucceedsForValidData()
        {
            var result = _service.ValidateRegistration(
                "John Doe", "123 Main St", "john@example.com", "5550199", "johndoe", "pass123", "pass123", false);

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void ValidateRegistration_FailsWhenPasswordsMismatch()
        {
            var result = _service.ValidateRegistration(
                "John Doe", "123 Main St", "john@example.com", "5550199", "johndoe", "pass123", "mismatch", false);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.ContainsKey("ConfirmPassword"));
        }

        [TestMethod]
        public void ValidateRegistration_FailsForDuplicateUsername()
        {
            var result = _service.ValidateRegistration(
                "John Doe", "123 Main St", "john@example.com", "5550199", "johndoe", "pass123", "pass123", true);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.ContainsKey("Username"));
        }

        [TestMethod]
        public void ValidateRegistration_FailsForInvalidEmail()
        {
            var result = _service.ValidateRegistration(
                "John Doe", "123 Main St", "john_invalid_email", "5550199", "johndoe", "pass123", "pass123", false);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.ContainsKey("Email"));
        }
    }
}
