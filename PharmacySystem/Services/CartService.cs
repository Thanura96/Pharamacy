using System;
using System.Collections.Generic;
using System.Linq;
using PharmacySystem.Models;
using PharmacySystem.Services.Interfaces;

namespace PharmacySystem.Services
{
    public class CartService : ICartService
    {
        private readonly List<CartItem> _items = new List<CartItem>();
        private readonly MedicineService _medicineService;

        public CartService(MedicineService medicineService)
        {
            _medicineService = medicineService ?? throw new ArgumentNullException(nameof(medicineService));
        }

        public IReadOnlyList<CartItem> Items => _items.AsReadOnly();

        public bool AddToCart(Medicine medicine, int quantity, out string errorMessage)
        {
            errorMessage = null;

            if (medicine == null)
            {
                errorMessage = "Medicine is required.";
                return false;
            }

            if (quantity <= 0)
            {
                errorMessage = "Quantity must be greater than zero.";
                return false;
            }

            var currentStock = _medicineService.GetMedicineById(medicine.Id)?.Quantity ?? medicine.Quantity;
            var existing = _items.FirstOrDefault(i => i.MedicineId == medicine.Id);
            int totalInCart = existing != null ? existing.Quantity + quantity : quantity;

            if (totalInCart > currentStock)
            {
                errorMessage = $"Insufficient stock. Only {currentStock} units available.";
                return false;
            }

            decimal discountMultiplier = 1m - (medicine.DiscountPercentage / 100m);
            // Final Price = Price - (Price × DiscountPercentage / 100)
            decimal unitPrice = medicine.Price * discountMultiplier;

            if (existing != null)
            {
                existing.Quantity += quantity;
                existing.SubTotal = existing.Quantity * existing.UnitPrice;
            }
            else
            {
                _items.Add(new CartItem
                {
                    MedicineId = medicine.Id,
                    MedicineName = medicine.Name,
                    Quantity = quantity,
                    UnitPrice = unitPrice,
                    SubTotal = quantity * unitPrice
                });
            }

            return true;
        }

        public bool RemoveFromCart(string medicineId)
        {
            if (string.IsNullOrWhiteSpace(medicineId))
            {
                return false;
            }

            var item = _items.FirstOrDefault(i => i.MedicineId == medicineId);
            if (item == null)
            {
                return false;
            }

            _items.Remove(item);
            return true;
        }

        public bool UpdateQuantity(string medicineId, int quantity, out string errorMessage)
        {
            errorMessage = null;

            if (string.IsNullOrWhiteSpace(medicineId))
            {
                errorMessage = "Medicine ID is required.";
                return false;
            }

            if (quantity <= 0)
            {
                errorMessage = "Quantity must be greater than zero.";
                return false;
            }

            var item = _items.FirstOrDefault(i => i.MedicineId == medicineId);
            if (item == null)
            {
                errorMessage = "Item not found in cart.";
                return false;
            }

            var medicine = _medicineService.GetMedicineById(medicineId);
            if (medicine == null)
            {
                errorMessage = "Medicine no longer available.";
                return false;
            }

            if (quantity > medicine.Quantity)
            {
                errorMessage = $"Insufficient stock. Only {medicine.Quantity} units available.";
                return false;
            }

            item.Quantity = quantity;
            item.SubTotal = item.Quantity * item.UnitPrice;
            return true;
        }

        public decimal CalculateTotal()
        {
            decimal total = 0m;
            foreach (var item in _items)
            {
                total += item.SubTotal;
            }
            return total;
        }

        public decimal CalculateDiscount()
        {
            decimal discount = 0m;
            foreach (var item in _items)
            {
                var medicine = _medicineService.GetMedicineById(item.MedicineId);
                if (medicine != null && medicine.DiscountPercentage > 0)
                {
                    decimal originalCost = item.Quantity * medicine.Price;
                    discount += originalCost - item.SubTotal;
                }
            }
            return discount;
        }

        public bool RequiresPrescription()
        {
            foreach (var item in _items)
            {
                var medicine = _medicineService.GetMedicineById(item.MedicineId);
                if (medicine != null && medicine.RequiresPrescription)
                {
                    return true;
                }
            }
            return false;
        }

        public List<OrderItem> ToOrderItems()
        {
            return _items.Select(item => new OrderItem
            {
                MedicineId = item.MedicineId,
                MedicineName = item.MedicineName,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                SubTotal = item.SubTotal
            }).ToList();
        }

        public void Clear()
        {
            _items.Clear();
        }
    }
}
