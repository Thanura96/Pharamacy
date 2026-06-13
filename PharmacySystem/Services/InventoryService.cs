using System;
using System.Collections.Generic;
using System.Linq;
using PharmacySystem.Models;
using PharmacySystem.Repositories;
using PharmacySystem.Services.Interfaces;

namespace PharmacySystem.Services
{
    public class InventoryService : IInventoryService
    {
        public const int LowStockThreshold = 10;

        private readonly IMedicineRepository _medicineRepository;

        public InventoryService(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        public void UpdateStock(string medicineId, int quantitySold)
        {
            if (string.IsNullOrWhiteSpace(medicineId))
            {
                throw new ArgumentException("Medicine ID is required.");
            }

            if (quantitySold <= 0)
            {
                throw new ArgumentException("Quantity sold must be greater than zero.");
            }

            var medicine = _medicineRepository.GetById(medicineId);
            if (medicine == null)
            {
                throw new InvalidOperationException("Medicine not found in the database.");
            }

            if (medicine.ExpiryDate.Date < DateTime.Today)
            {
                throw new InvalidOperationException(
                    $"The medicine {medicine.Name} expired on {medicine.ExpiryDate.ToShortDateString()}. Cannot sell expired medicines.");
            }

            if (medicine.Quantity < quantitySold)
            {
                throw new InvalidOperationException(
                    $"Insufficient stock. Only {medicine.Quantity} units of {medicine.Name} are available.");
            }

            medicine.Quantity -= quantitySold;
            _medicineRepository.Update(medicine);
        }

        public List<Medicine> CheckLowStock()
        {
            return _medicineRepository.GetAll()
                .Where(m => m.Quantity < LowStockThreshold)
                .OrderBy(m => m.Quantity)
                .ToList();
        }

        public List<Medicine> CheckExpiryDates()
        {
            return _medicineRepository.GetAll()
                .Where(m => m.ExpiryDate.Date < DateTime.Today)
                .OrderBy(m => m.ExpiryDate)
                .ToList();
        }

        public List<Medicine> GetAvailableMedicines()
        {
            return _medicineRepository.GetAll()
                .Where(m => m.Quantity > 0 && m.ExpiryDate.Date >= DateTime.Today)
                .OrderBy(m => m.Name)
                .ToList();
        }
    }
}
