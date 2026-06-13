using System.Collections.Generic;
using MongoDB.Driver;
using PharmacySystem.Database;
using PharmacySystem.Models;

namespace PharmacySystem.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly MongoDbContext _context;

        public MedicineRepository(MongoDbContext context)
        {
            _context = context;
        }

        public void Add(Medicine medicine)
        {
            _context.Medicines.InsertOne(medicine);
        }

        public void Update(Medicine medicine)
        {
            var filter = Builders<Medicine>.Filter.Eq(m => m.Id, medicine.Id);
            _context.Medicines.ReplaceOne(filter, medicine);
        }

        public void Delete(string id)
        {
            var filter = Builders<Medicine>.Filter.Eq(m => m.Id, id);
            _context.Medicines.DeleteOne(filter);
        }

        public Medicine GetById(string id)
        {
            var filter = Builders<Medicine>.Filter.Eq(m => m.Id, id);
            return _context.Medicines.Find(filter).FirstOrDefault();
        }

        public List<Medicine> GetAll()
        {
            return _context.Medicines.Find(_ => true).ToList();
        }
    }
}
