using System.Collections.Generic;
using System.Linq;
using PharmacySystem.Models;
using PharmacySystem.Repositories;

namespace PharmacySystem.Tests
{
    internal class InMemoryMedicineRepository : IMedicineRepository
    {
        private readonly List<Medicine> _items = new List<Medicine>();
        private int _idCounter = 1;

        public void Add(Medicine medicine)
        {
            medicine.Id = (_idCounter++).ToString();
            _items.Add(medicine);
        }

        public void Update(Medicine medicine)
        {
            var index = _items.FindIndex(m => m.Id == medicine.Id);
            if (index >= 0)
            {
                _items[index] = medicine;
            }
        }

        public void Delete(string id)
        {
            _items.RemoveAll(m => m.Id == id);
        }

        public Medicine GetById(string id)
        {
            return _items.FirstOrDefault(m => m.Id == id);
        }

        public List<Medicine> GetAll()
        {
            return _items.ToList();
        }
    }
}
