using System.Collections.Generic;
using System.Linq;
using PharmacySystem.Models;
using PharmacySystem.Repositories;

namespace PharmacySystem.Tests
{
    internal class InMemoryCustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _items = new List<Customer>();
        private int _idCounter = 1;

        public void Add(Customer customer)
        {
            customer.Id = (_idCounter++).ToString();
            _items.Add(customer);
        }

        public void Update(Customer customer)
        {
            var index = _items.FindIndex(c => c.Id == customer.Id);
            if (index >= 0)
            {
                _items[index] = customer;
            }
        }

        public void Delete(string id)
        {
            _items.RemoveAll(c => c.Id == id);
        }

        public Customer GetById(string id)
        {
            return _items.FirstOrDefault(c => c.Id == id);
        }

        public List<Customer> GetAll()
        {
            return _items.ToList();
        }
    }
}
