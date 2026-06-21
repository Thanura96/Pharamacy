using System;
using System.Collections.Generic;
using System.Linq;
using PharmacySystem.Models;
using PharmacySystem.Repositories;

namespace PharmacySystem.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public void AddCustomer(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            if (string.IsNullOrWhiteSpace(customer.Name)) throw new ArgumentException("Customer Name is required.");
            if (string.IsNullOrWhiteSpace(customer.Phone)) throw new ArgumentException("Customer Phone is required.");

            _repository.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            if (string.IsNullOrWhiteSpace(customer.Id)) throw new ArgumentException("Customer ID is required for update.");
            if (string.IsNullOrWhiteSpace(customer.Name)) throw new ArgumentException("Customer Name is required.");
            if (string.IsNullOrWhiteSpace(customer.Phone)) throw new ArgumentException("Customer Phone is required.");

            _repository.Update(customer);
        }

        public void DeleteCustomer(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("ID is required.");
            _repository.Delete(id);
        }

        public Customer GetCustomerById(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return null;
            return _repository.GetById(id);
        }

        public List<Customer> GetAllCustomers()
        {
            return _repository.GetAll();
        }

        public List<Customer> SearchCustomers(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return GetAllCustomers();
            }

            string query = searchTerm.Trim().ToLower();
            return _repository.GetAll()
                .Where(c => c.Name.ToLower().Contains(query) ||
                            c.Phone.Contains(query) ||
                            (!string.IsNullOrEmpty(c.Email) && c.Email.ToLower().Contains(query)))
                .ToList();
        }
    }
}
