using System.Collections.Generic;
using PharmacySystem.Models;

namespace PharmacySystem.Services.Interfaces
{
    public interface IInventoryService
    {
        void UpdateStock(string medicineId, int quantitySold);
        List<Medicine> CheckLowStock();
        List<Medicine> CheckExpiryDates();
        List<Medicine> GetAvailableMedicines();
    }
}
