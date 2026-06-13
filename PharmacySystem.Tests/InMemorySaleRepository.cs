using System;
using System.Collections.Generic;
using System.Linq;
using PharmacySystem.Models;
using PharmacySystem.Repositories;

namespace PharmacySystem.Tests
{
    internal class InMemorySaleRepository : ISaleRepository
    {
        private readonly List<Sale> _items = new List<Sale>();
        private int _idCounter = 1;

        public void AddSale(Sale sale)
        {
            sale.Id = (_idCounter++).ToString();
            _items.Add(sale);
        }

        public void Add(Sale sale) => AddSale(sale);

        public void Update(Sale sale)
        {
            var index = _items.FindIndex(s => s.Id == sale.Id);
            if (index >= 0)
            {
                _items[index] = sale;
            }
        }

        public void Delete(string id)
        {
            _items.RemoveAll(s => s.Id == id);
        }

        public Sale GetById(string id)
        {
            return _items.FirstOrDefault(s => s.Id == id);
        }

        public List<Sale> GetAllSales()
        {
            return _items.ToList();
        }

        public List<Sale> GetAll() => GetAllSales();

        public List<Sale> GetSalesByDate(DateTime date)
        {
            return _items.Where(s => s.SaleDate.Date == date.Date).ToList();
        }
    }
}
