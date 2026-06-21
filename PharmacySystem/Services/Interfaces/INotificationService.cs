using System.Collections.Generic;
using PharmacySystem.Models;

namespace PharmacySystem.Services.Interfaces
{
    public interface INotificationService
    {
        List<Medicine> GetExpiringWithinDays(int days);
        List<Medicine> GetExpiredMedicines();
    }
}
