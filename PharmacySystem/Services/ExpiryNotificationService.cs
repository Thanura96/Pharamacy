using System;
using System.Collections.Generic;
using System.Linq;
using PharmacySystem.Models;
using PharmacySystem.Repositories;

namespace PharmacySystem.Services
{
    public class ExpiryNotificationService : Interfaces.INotificationService
    {
        private readonly IMedicineRepository _medicineRepository;

        public ExpiryNotificationService(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository ?? throw new ArgumentNullException(nameof(medicineRepository));
        }

        public List<Medicine> GetExpiringWithinDays(int days)
        {
            if (days < 0)
            {
                throw new ArgumentException("Days must be zero or greater.");
            }

            var today = DateTime.Today;
            var cutoff = today.AddDays(days);

            return _medicineRepository.GetAll()
                .Where(m => m.ExpiryDate.Date >= today && m.ExpiryDate.Date <= cutoff)
                .OrderBy(m => m.ExpiryDate)
                .ToList();
        }

        public List<Medicine> GetExpiredMedicines()
        {
            var today = DateTime.Today;
            return _medicineRepository.GetAll()
                .Where(m => m.ExpiryDate.Date < today)
                .OrderBy(m => m.ExpiryDate)
                .ToList();
        }
    }
}
