using System;
using PharmacySystem.Models;

namespace PharmacySystem.Services.Interfaces
{
    public interface IValidationService
    {
        ValidationResult ValidateMedicine(string name, string category, string priceText, int quantity, DateTime expiryDate);
        ValidationResult ValidateCustomer(string name, string phone);
        ValidationResult ValidateSale(string customerName, int quantity, int availableStock);
        ValidationResult ValidateLogin(string username, string password);
    }
}
