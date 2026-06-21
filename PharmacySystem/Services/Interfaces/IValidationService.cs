using System;
using System.Collections.Generic;
using PharmacySystem.Models;

namespace PharmacySystem.Services.Interfaces
{
    public interface IValidationService
    {
        ValidationResult ValidateMedicine(string name, string category, string priceText, int quantity, DateTime expiryDate, string discountText, string dosage, string supplier);
        ValidationResult ValidateCustomer(string name, string phone, string address, string email, string username, string password, bool isUsernameDuplicate);
        ValidationResult ValidateCustomerUpdate(string name, string phone, string address, string email);
        ValidationResult ValidateSale(string customerName, int quantity, int availableStock);
        ValidationResult ValidateLogin(string username, string password);
        ValidationResult ValidateRegistration(string fullName, string address, string email, string phone, string username, string password, string confirmPassword, bool isUsernameDuplicate);
        ValidationResult ValidateOrder(IReadOnlyList<CartItem> items, bool prescriptionRequired, string prescriptionPath, Dictionary<string, Medicine> medicinesById);
    }
}
