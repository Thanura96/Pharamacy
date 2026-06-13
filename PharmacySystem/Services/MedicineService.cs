using System;
using System.Collections.Generic;
using System.Linq;
using PharmacySystem.Models;
using PharmacySystem.Repositories;

namespace PharmacySystem.Services
{
    public class MedicineService
    {
        private readonly IMedicineRepository _repository;

        public MedicineService(IMedicineRepository repository)
        {
            _repository = repository;
        }

        public void AddMedicine(Medicine medicine)
        {
            if (medicine == null) throw new ArgumentNullException(nameof(medicine));
            if (string.IsNullOrWhiteSpace(medicine.Name)) throw new ArgumentException("Medicine Name is required.");
            if (medicine.Price < 0) throw new ArgumentException("Price cannot be negative.");
            if (medicine.Quantity < 0) throw new ArgumentException("Quantity cannot be negative.");

            _repository.Add(medicine);
        }

        public void UpdateMedicine(Medicine medicine)
        {
            if (medicine == null) throw new ArgumentNullException(nameof(medicine));
            if (string.IsNullOrWhiteSpace(medicine.Id)) throw new ArgumentException("Medicine ID is required for update.");
            if (string.IsNullOrWhiteSpace(medicine.Name)) throw new ArgumentException("Medicine Name is required.");
            if (medicine.Price < 0) throw new ArgumentException("Price cannot be negative.");
            if (medicine.Quantity < 0) throw new ArgumentException("Quantity cannot be negative.");

            _repository.Update(medicine);
        }

        public void DeleteMedicine(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("ID is required.");
            _repository.Delete(id);
        }

        public Medicine GetMedicineById(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return null;
            return _repository.GetById(id);
        }

        public List<Medicine> GetAllMedicines()
        {
            return _repository.GetAll();
        }

        public List<Medicine> SearchMedicines(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return GetAllMedicines();
            }

            string query = searchTerm.Trim().ToLower();
            return _repository.GetAll()
                .Where(m => m.Name.ToLower().Contains(query) || m.Category.ToLower().Contains(query))
                .ToList();
        }
    }
}
