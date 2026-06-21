using System;
using System.Collections.Generic;
using PharmacySystem.Models;

namespace PharmacySystem.Services
{
    public enum MedicineSortOption
    {
        NameAscending,
        NameDescending,
        PriceAscending,
        PriceDescending,
        CategoryAscending
    }

    public class MedicineSearchService
    {
        /// <summary>
        /// Linear search: iterates through each medicine once and applies all filters.
        /// </summary>
        public List<Medicine> Search(
            List<Medicine> medicines,
            string name,
            string category,
            decimal? minPrice,
            decimal? maxPrice)
        {
            var results = new List<Medicine>();

            if (medicines == null)
            {
                return results;
            }

            string nameFilter = string.IsNullOrWhiteSpace(name) ? null : name.Trim();
            string categoryFilter = string.IsNullOrWhiteSpace(category) ? null : category.Trim();

            for (int i = 0; i < medicines.Count; i++)
            {
                var medicine = medicines[i];

                if (medicine.Quantity <= 0 || medicine.ExpiryDate.Date <= DateTime.Today)
                {
                    continue;
                }

                if (nameFilter != null &&
                    medicine.Name.IndexOf(nameFilter, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    continue;
                }

                if (categoryFilter != null &&
                    medicine.Category.IndexOf(categoryFilter, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    continue;
                }

                if (minPrice.HasValue && medicine.Price < minPrice.Value)
                {
                    continue;
                }

                if (maxPrice.HasValue && medicine.Price > maxPrice.Value)
                {
                    continue;
                }

                results.Add(medicine);
            }

            return results;
        }

        public List<Medicine> Sort(List<Medicine> medicines, MedicineSortOption sortOption)
        {
            if (medicines == null || medicines.Count <= 1)
            {
                return medicines ?? new List<Medicine>();
            }

            var sorted = new List<Medicine>(medicines);

            switch (sortOption)
            {
                case MedicineSortOption.NameDescending:
                    sorted.Sort((a, b) => string.Compare(b.Name, a.Name, StringComparison.OrdinalIgnoreCase));
                    break;
                case MedicineSortOption.PriceAscending:
                    sorted.Sort((a, b) => a.Price.CompareTo(b.Price));
                    break;
                case MedicineSortOption.PriceDescending:
                    sorted.Sort((a, b) => b.Price.CompareTo(a.Price));
                    break;
                case MedicineSortOption.CategoryAscending:
                    sorted.Sort((a, b) => string.Compare(a.Category, b.Category, StringComparison.OrdinalIgnoreCase));
                    break;
                default:
                    sorted.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));
                    break;
            }

            return sorted;
        }
    }
}
