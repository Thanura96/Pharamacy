using System.Collections.Generic;
using MongoDB.Driver;
using PharmacySystem.Database;
using PharmacySystem.Models;

namespace PharmacySystem.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MongoDbContext _context;

        public CustomerRepository(MongoDbContext context)
        {
            _context = context;
        }

        public void Add(Customer customer)
        {
            _context.Customers.InsertOne(customer);
        }

        public void Update(Customer customer)
        {
            var filter = Builders<Customer>.Filter.Eq(c => c.Id, customer.Id);
            _context.Customers.ReplaceOne(filter, customer);
        }

        public void Delete(string id)
        {
            var filter = Builders<Customer>.Filter.Eq(c => c.Id, id);
            _context.Customers.DeleteOne(filter);
        }

        public Customer GetById(string id)
        {
            var filter = Builders<Customer>.Filter.Eq(c => c.Id, id);
            return _context.Customers.Find(filter).FirstOrDefault();
        }

        public List<Customer> GetAll()
        {
            return _context.Customers.Find(_ => true).ToList();
        }
    }
}
