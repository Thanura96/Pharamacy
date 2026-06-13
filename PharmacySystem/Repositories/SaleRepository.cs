using System;
using System.Collections.Generic;
using MongoDB.Driver;
using PharmacySystem.Database;
using PharmacySystem.Models;

namespace PharmacySystem.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly MongoDbContext _context;

        public SaleRepository(MongoDbContext context)
        {
            _context = context;
        }

        public void AddSale(Sale sale)
        {
            _context.Sales.InsertOne(sale);
        }

        public void Add(Sale sale)
        {
            AddSale(sale);
        }

        public void Update(Sale sale)
        {
            var filter = Builders<Sale>.Filter.Eq(s => s.Id, sale.Id);
            _context.Sales.ReplaceOne(filter, sale);
        }

        public void Delete(string id)
        {
            var filter = Builders<Sale>.Filter.Eq(s => s.Id, id);
            _context.Sales.DeleteOne(filter);
        }

        public Sale GetById(string id)
        {
            var filter = Builders<Sale>.Filter.Eq(s => s.Id, id);
            return _context.Sales.Find(filter).FirstOrDefault();
        }

        public List<Sale> GetAllSales()
        {
            return _context.Sales.Find(_ => true).ToList();
        }

        public List<Sale> GetAll()
        {
            return GetAllSales();
        }

        public List<Sale> GetSalesByDate(DateTime date)
        {
            var start = date.Date;
            var end = start.AddDays(1);
            var filter = Builders<Sale>.Filter.Gte(s => s.SaleDate, start)
                         & Builders<Sale>.Filter.Lt(s => s.SaleDate, end);
            return _context.Sales.Find(filter).ToList();
        }
    }
}
