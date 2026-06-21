using System;
using System.Collections.Generic;
using PharmacySystem.Models;
using PharmacySystem.Services.Interfaces;
using PharmacySystem.Utilities;

namespace PharmacySystem.Services
{
    public class ValidationService : IValidationService
    {
        public ValidationResult ValidateMedicine(string name, string category, string priceText, int quantity, DateTime expiryDate, string discountText, string dosage, string supplier)
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

            if (quantity < 0)
            {
                result.AddError("Quantity", "Stock quantity cannot be negative.");
            }

            if (expiryDate.Date <= DateTime.Today)
            {
                result.AddError("ExpiryDate", "Expiry date must be in the future.");
            }

            if (!ValidationHelper.IsDecimal(discountText, out decimal discount) || discount < 0 || discount > 100)
            {
                result.AddError("DiscountPercentage", "Discount must be a number between 0 and 100.");
            }

            if (ValidationHelper.IsEmpty(dosage))
            {
                result.AddError("Dosage", "Dosage is required.");
            }

            if (ValidationHelper.IsEmpty(supplier))
            {
                result.AddError("Supplier", "Supplier is required.");
            }

            return result;
        }

        public ValidationResult ValidateCustomer(string name, string phone, string address, string email, string username, string password, bool isUsernameDuplicate)
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

            if (ValidationHelper.IsEmpty(address))
            {
                result.AddError("Address", "Address is required.");
            }

            if (ValidationHelper.IsEmpty(email))
            {
                result.AddError("Email", "Email is required.");
            }
            else if (!ValidationHelper.IsValidEmail(email))
            {
                result.AddError("Email", "Please enter a valid email address.");
            }

            if (ValidationHelper.IsEmpty(username))
            {
                result.AddError("Username", "Username is required.");
            }
            else if (isUsernameDuplicate)
            {
                result.AddError("Username", "Username is already taken.");
            }

            if (ValidationHelper.IsEmpty(password))
            {
                result.AddError("Password", "Password is required.");
            }

            return result;
        }

        public ValidationResult ValidateCustomerUpdate(string name, string phone, string address, string email)
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

            if (ValidationHelper.IsEmpty(address))
            {
                result.AddError("Address", "Address is required.");
            }

            if (ValidationHelper.IsEmpty(email))
            {
                result.AddError("Email", "Email is required.");
            }
            else if (!ValidationHelper.IsValidEmail(email))
            {
                result.AddError("Email", "Please enter a valid email address.");
            }

            return result;
        }

        public ValidationResult ValidateOrder(IReadOnlyList<CartItem> items, bool prescriptionRequired, string prescriptionPath, Dictionary<string, Medicine> medicinesById)
        {
            var result = new ValidationResult();

            if (items == null || items.Count == 0)
            {
                result.AddError("Cart", "Your cart is empty.");
                return result;
            }

            if (prescriptionRequired && ValidationHelper.IsEmpty(prescriptionPath))
            {
                result.AddError("Prescription", "A prescription upload is required for one or more medicines in your cart.");
            }

            foreach (var item in items)
            {
                if (medicinesById == null || !medicinesById.TryGetValue(item.MedicineId, out var medicine) || medicine == null)
                {
                    result.AddError("Cart", $"Medicine '{item.MedicineName}' is no longer available.");
                    continue;
                }

                if (item.Quantity <= 0)
                {
                    result.AddError("Quantity", $"Quantity for '{item.MedicineName}' must be greater than zero.");
                }
                else if (item.Quantity > medicine.Quantity)
                {
                    result.AddError("Quantity", $"Insufficient stock for '{item.MedicineName}'. Only {medicine.Quantity} units available.");
                }

                if (medicine.RequiresPrescription && ValidationHelper.IsEmpty(prescriptionPath))
                {
                    result.AddError("Prescription", $"'{item.MedicineName}' requires a prescription before checkout.");
                }
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

        public ValidationResult ValidateRegistration(string fullName, string address, string email, string phone, string username, string password, string confirmPassword, bool isUsernameDuplicate)
        {
            var result = new ValidationResult();

            if (ValidationHelper.IsEmpty(fullName))
            {
                result.AddError("FullName", "Full name is required.");
            }

            if (ValidationHelper.IsEmpty(address))
            {
                result.AddError("Address", "Address is required.");
            }

            if (ValidationHelper.IsEmpty(email))
            {
                result.AddError("Email", "Email is required.");
            }
            else if (!ValidationHelper.IsValidEmail(email))
            {
                result.AddError("Email", "Please enter a valid email address.");
            }

            if (ValidationHelper.IsEmpty(phone))
            {
                result.AddError("Phone", "Phone number is required.");
            }
            else if (!ValidationHelper.IsValidPhone(phone))
            {
                result.AddError("Phone", "Please enter a valid phone number.");
            }

            if (ValidationHelper.IsEmpty(username))
            {
                result.AddError("Username", "Username is required.");
            }
            else if (isUsernameDuplicate)
            {
                result.AddError("Username", "Username is already taken.");
            }

            if (ValidationHelper.IsEmpty(password))
            {
                result.AddError("Password", "Password is required.");
            }

            if (ValidationHelper.IsEmpty(confirmPassword))
            {
                result.AddError("ConfirmPassword", "Confirm password is required.");
            }
            else if (password != confirmPassword)
            {
                result.AddError("ConfirmPassword", "Passwords do not match.");
            }

            return result;
        }
    }
}
