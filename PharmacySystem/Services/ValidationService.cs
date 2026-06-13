using System;
using PharmacySystem.Models;
using PharmacySystem.Services.Interfaces;
using PharmacySystem.Utilities;

namespace PharmacySystem.Services
{
    public class ValidationService : IValidationService
    {
        public ValidationResult ValidateMedicine(string name, string category, string priceText, int quantity, DateTime expiryDate)
        {
            var result = new ValidationResult();

            if (ValidationHelper.IsEmpty(name))
            {
                result.AddError("Name", "Medicine name is required.");
            }

            if (ValidationHelper.IsEmpty(category))
            {
                result.AddError("Category", "Category is required.");
            }

            if (!ValidationHelper.IsDecimal(priceText, out decimal price) || price <= 0)
            {
                result.AddError("Price", "Price must be a valid number greater than zero.");
            }

            if (quantity <= 0)
            {
                result.AddError("Quantity", "Quantity must be greater than zero.");
            }

            if (expiryDate.Date <= DateTime.Today)
            {
                result.AddError("ExpiryDate", "Expiry date must be in the future.");
            }

            return result;
        }

        public ValidationResult ValidateCustomer(string name, string phone)
        {
            var result = new ValidationResult();

            if (ValidationHelper.IsEmpty(name))
            {
                result.AddError("Name", "Customer name is required.");
            }

            if (ValidationHelper.IsEmpty(phone))
            {
                result.AddError("Phone", "Phone number is required.");
            }
            else if (!ValidationHelper.IsValidPhone(phone))
            {
                result.AddError("Phone", "Please enter a valid phone number.");
            }

            return result;
        }

        public ValidationResult ValidateSale(string customerName, int quantity, int availableStock)
        {
            var result = new ValidationResult();

            if (ValidationHelper.IsEmpty(customerName))
            {
                result.AddError("CustomerName", "Customer name is required.");
            }

            if (quantity <= 0)
            {
                result.AddError("Quantity", "Quantity must be greater than zero.");
            }
            else if (quantity > availableStock)
            {
                result.AddError("Quantity", $"Insufficient stock. Only {availableStock} units available.");
            }

            return result;
        }

        public ValidationResult ValidateLogin(string username, string password)
        {
            var result = new ValidationResult();

            if (ValidationHelper.IsEmpty(username))
            {
                result.AddError("Username", "Username is required.");
            }

            if (ValidationHelper.IsEmpty(password))
            {
                result.AddError("Password", "Password is required.");
            }

            return result;
        }
    }
}
