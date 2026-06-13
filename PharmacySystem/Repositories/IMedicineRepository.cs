using System.Collections.Generic;
using PharmacySystem.Models;

namespace PharmacySystem.Repositories
{
    public interface IMedicineRepository
    {
        void Add(Medicine medicine);
        void Update(Medicine medicine);
        void Delete(string id);
        Medicine GetById(string id);
        List<Medicine> GetAll();
    }
}
