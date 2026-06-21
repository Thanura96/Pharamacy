using System.Collections.Generic;
using PharmacySystem.Models;

namespace PharmacySystem.Services.Interfaces
{
    public interface ICartService
    {
        IReadOnlyList<CartItem> Items { get; }
        bool AddToCart(Medicine medicine, int quantity, out string errorMessage);
        bool RemoveFromCart(string medicineId);
        bool UpdateQuantity(string medicineId, int quantity, out string errorMessage);
        decimal CalculateTotal();
        decimal CalculateDiscount();
        bool RequiresPrescription();
        List<OrderItem> ToOrderItems();
        void Clear();
    }
}
