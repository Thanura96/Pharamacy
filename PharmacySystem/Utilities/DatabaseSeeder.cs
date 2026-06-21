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
                            ExpiryDate = DateTime.Today.AddYears(2),
                            Dosage = "500mg",
                            Supplier = "PharmaCorp Ltd",
                            DiscountPercentage = 5m,
                            RequiresPrescription = false
                        },
                        new Medicine
                        {
                            Name = "Amoxicillin",
                            Category = "Antibiotics",
                            Price = 12.00m,
                            Quantity = 50,
                            ExpiryDate = DateTime.Today.AddYears(1),
                            Dosage = "250mg",
                            Supplier = "MedSupply Inc",
                            DiscountPercentage = 0m,
                            RequiresPrescription = true
                        },
                        new Medicine
                        {
                            Name = "Vitamin C",
                            Category = "Supplements",
                            Price = 8.75m,
                            Quantity = 80,
                            ExpiryDate = DateTime.Today.AddYears(3),
                            Dosage = "1000mg",
                            Supplier = "HealthPlus",
                            DiscountPercentage = 10m,
                            RequiresPrescription = false
                        }
                    };
                    context.Medicines.InsertMany(medicines);
                    logger?.LogInfo("Seeded sample medicines into PharmacyDB.");
                }

                if (context.Customers.CountDocuments(_ => true) == 0)
                {
                    var customers = new List<Customer>
                    {
                        new Customer
                        {
                            FullName = "John Doe",
                            Phone = "5550199",
                            Address = "123 Main Street, Cardiff",
                            Email = "john.doe@example.com",
                            Username = "johndoe",
                            Password = "pass123"
                        },
                        new Customer
                        {
                            FullName = "Jane Smith",
                            Phone = "5550144",
                            Address = "45 Oak Avenue, Cardiff",
                            Email = "jane.smith@example.com",
                            Username = "janesmith",
                            Password = "pass123"
                        },
                        new Customer
                        {
                            FullName = "Robert Johnson",
                            Phone = "5550177",
                            Address = "78 Park Lane, Cardiff",
                            Email = "robert.j@example.com",
                            Username = "robertj",
                            Password = "pass123"
                        },
                        new Customer
                        {
                            FullName = "Emily Davis",
                            Phone = "5550123",
                            Address = "12 River Road, Cardiff",
                            Email = "emily.davis@example.com",
                            Username = "emilyd",
                            Password = "pass123"
                        }
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
