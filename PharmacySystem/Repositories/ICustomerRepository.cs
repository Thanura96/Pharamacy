using System.Collections.Generic;
using PharmacySystem.Models;

namespace PharmacySystem.Repositories
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(string id);
        Customer GetById(string id);
        List<Customer> GetAll();
    }
}
