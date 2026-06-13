using System;
using System.Collections.Generic;
using MongoDB.Driver;
using PharmacySystem.Database;
using PharmacySystem.Logging;
using PharmacySystem.Models;

namespace PharmacySystem.Utilities
{
    public static class DatabaseSeeder
    {
        public static void Seed(MongoDbContext context, ILogger logger = null)
        {
            try
            {
                if (context.Medicines.CountDocuments(_ => true) == 0)
                {
                    var medicines = new List<Medicine>
                    {
                        new Medicine
                        {
                            Name = "Paracetamol",
                            Category = "Analgesics",
                            Price = 5.50m,
                            Quantity = 100,
                            ExpiryDate = DateTime.Today.AddYears(2)
                        },
                        new Medicine
                        {
                            Name = "Amoxicillin",
                            Category = "Antibiotics",
                            Price = 12.00m,
                            Quantity = 50,
                            ExpiryDate = DateTime.Today.AddYears(1)
                        },
                        new Medicine
                        {
                            Name = "Vitamin C",
                            Category = "Supplements",
                            Price = 8.75m,
                            Quantity = 8,
                            ExpiryDate = DateTime.Today.AddYears(3)
                        }
                    };
                    context.Medicines.InsertMany(medicines);
                    logger?.LogInfo("Seeded sample medicines into PharmacyDB.");
                }

                if (context.Customers.CountDocuments(_ => true) == 0)
                {
                    var customers = new List<Customer>
                    {
                        new Customer { Name = "John Doe", Phone = "5550199" },
                        new Customer { Name = "Jane Smith", Phone = "5550144" },
                        new Customer { Name = "Robert Johnson", Phone = "5550177" },
                        new Customer { Name = "Emily Davis", Phone = "5550123" }
                    };
                    context.Customers.InsertMany(customers);
                    logger?.LogInfo("Seeded sample customers into PharmacyDB.");
                }
            }
            catch (Exception ex)
            {
                logger?.LogError("Database seeding skipped or failed.", ex);
            }
        }
    }
}
