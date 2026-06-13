using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var result = _service.ValidateMedicine("", "", "0", 0, DateTime.Today);

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void ValidateCustomer_FailsWhenPhoneInvalid()
        {
            var result = _service.ValidateCustomer("John Doe", "");

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void ValidateSale_FailsWhenStockInsufficient()
        {
            var result = _service.ValidateSale("John Doe", 20, 5);

            Assert.IsFalse(result.IsValid);
        }
    }
}
