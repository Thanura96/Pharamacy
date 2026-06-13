using System;
using System.Collections.Generic;
using PharmacySystem.Models;
using PharmacySystem.Repositories;
using PharmacySystem.Services.Interfaces;

namespace PharmacySystem.Services
{
    public class SaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMedicineRepository _medicineRepository;
        private readonly IInventoryService _inventoryService;

        public SaleService(
            ISaleRepository saleRepository,
            IMedicineRepository medicineRepository,
            IInventoryService inventoryService = null)
        {
            _saleRepository = saleRepository;
            _medicineRepository = medicineRepository;
            _inventoryService = inventoryService ?? new InventoryService(medicineRepository);
        }

        public decimal CalculateTotal(decimal unitPrice, int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.");
            }

            return unitPrice * quantity;
        }

        public void ProcessSale(Sale sale, string medicineId)
        {
            if (sale == null)
            {
                throw new ArgumentNullException(nameof(sale));
            }

            if (sale.Quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.");
            }

            if (string.IsNullOrWhiteSpace(sale.CustomerName))
            {
                throw new ArgumentException("Customer name is required.");
            }

            var medicine = _medicineRepository.GetById(medicineId);
            if (medicine == null)
            {
                throw new InvalidOperationException("Medicine not found in the database.");
            }

            _inventoryService.UpdateStock(medicineId, sale.Quantity);

            sale.MedicineName = medicine.Name;
            sale.TotalAmount = medicine.Price * sale.Quantity;
            if (sale.SaleDate == default(DateTime))
            {
                sale.SaleDate = DateTime.Now;
            }

            _saleRepository.AddSale(sale);
        }

        public List<Sale> GetAllSales()
        {
            return _saleRepository.GetAllSales();
        }

        public List<Sale> GetSalesByDate(DateTime date)
        {
            return _saleRepository.GetSalesByDate(date);
        }
    }
}
