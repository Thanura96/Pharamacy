using System;
using System.Configuration;
using MongoDB.Driver;
using PharmacySystem.Models;

namespace PharmacySystem.Database
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext()
        {
            string connectionString = null;
            try
            {
                var connSetting = ConfigurationManager.ConnectionStrings["MongoDb"];
                if (connSetting != null)
                {
                    connectionString = connSetting.ConnectionString;
                }
            }
            catch (Exception)
            {
                // Fallback in case of runtime configuration issues
            }

            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = "mongodb://localhost:27017";
            }

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase("PharmacyDB");
        }

        public IMongoDatabase Database => _database;

        public IMongoCollection<Medicine> Medicines => _database.GetCollection<Medicine>("Medicines");
        public IMongoCollection<Customer> Customers => _database.GetCollection<Customer>("Customers");
        public IMongoCollection<Sale> Sales => _database.GetCollection<Sale>("Sales");
        public IMongoCollection<Order> Orders => _database.GetCollection<Order>("Orders");
    }
}
