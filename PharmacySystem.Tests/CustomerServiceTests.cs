using Microsoft.VisualStudio.TestTools.UnitTesting;
using PharmacySystem.Models;
using PharmacySystem.Services;

namespace PharmacySystem.Tests
{
    [TestClass]
    public class CustomerServiceTests
    {
        private CustomerService _service;

        [TestInitialize]
        public void Setup()
        {
            _service = new CustomerService(new InMemoryCustomerRepository());
        }

        [TestMethod]
        public void AddCustomer_AddsRecordSuccessfully()
        {
            _service.AddCustomer(new Customer { Name = "John Doe", Phone = "5550199" });

            Assert.AreEqual(1, _service.GetAllCustomers().Count);
        }

        [TestMethod]
        public void SearchCustomers_ReturnsMatchingRecords()
        {
            _service.AddCustomer(new Customer { Name = "Jane Smith", Phone = "5550144" });
            _service.AddCustomer(new Customer { Name = "Robert Johnson", Phone = "5550177" });

            var results = _service.SearchCustomers("jane");

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Jane Smith", results[0].Name);
        }
    }
}
