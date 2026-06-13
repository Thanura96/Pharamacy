using System;
using System.Collections.Generic;
using PharmacySystem.Models;

namespace PharmacySystem.Repositories
{
    public interface ISaleRepository
    {
        void AddSale(Sale sale);
        void Update(Sale sale);
        void Delete(string id);
        Sale GetById(string id);
        List<Sale> GetAllSales();
        List<Sale> GetSalesByDate(DateTime date);

        // Legacy aliases for backward compatibility
        void Add(Sale sale);
        List<Sale> GetAll();
    }
}
