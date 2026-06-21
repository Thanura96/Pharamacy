using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PharmacySystem.Core;
using PharmacySystem.Models;
using PharmacySystem.Services;
using PharmacySystem.Services.Interfaces;

namespace PharmacySystem.Forms
{
    public partial class SearchMedicineForm : BaseForm
    {
        private readonly ICartService _cartService;
        private readonly MedicineSearchService _searchService = new MedicineSearchService();
        private List<Medicine> _searchResults = new List<Medicine>();

        public SearchMedicineForm(PharmacyAppContext appContext, ICartService cartService) : base(appContext)
        {
            InitializeComponent();
            _cartService = cartService;
        }

        private void SearchMedicineForm_Load(object sender, EventArgs e)
        {
            cmbSortBy.DataSource = Enum.GetValues(typeof(MedicineSortOption));
            cmbSortBy.SelectedItem = MedicineSortOption.NameAscending;
            if (EnsureDatabaseAvailable())
            {
                PerformSearch();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!EnsureDatabaseAvailable()) return;
            PerformSearch();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchName.Clear();
            txtSearchCategory.Clear();
            txtMinPrice.Clear();
            txtMaxPrice.Clear();
            cmbSortBy.SelectedItem = MedicineSortOption.NameAscending;
            if (EnsureDatabaseAvailable())
            {
                PerformSearch();
            }
        }

        private void PerformSearch()
        {
            try
            {
                if (!TryParseOptionalPrice(txtMinPrice.Text, out decimal? minPrice))
                {
                    return;
                }

                if (!TryParseOptionalPrice(txtMaxPrice.Text, out decimal? maxPrice))
                {
                    return;
                }

                if (minPrice.HasValue && maxPrice.HasValue && minPrice.Value > maxPrice.Value)
                {
                    ShowWarning("Minimum price cannot be greater than maximum price.", "Validation");
                    return;
                }

                var allMedicines = AppContext.MedicineService.GetAllMedicines();
                var filtered = _searchService.Search(
                    allMedicines,
                    txtSearchName.Text,
                    txtSearchCategory.Text,
                    minPrice,
                    maxPrice);

                var sortOption = (MedicineSortOption)cmbSortBy.SelectedItem;
                _searchResults = _searchService.Sort(filtered, sortOption);

                dgvResults.DataSource = _searchResults.Select(m => new
                {
                    m.Id,
                    m.Name,
                    m.Category,
                    Price = $"${m.Price:F2}",
                    Available = m.Quantity,
                    m.Dosage,
                    Discount = $"{m.DiscountPercentage:F0}%",
                    Prescription = m.RequiresPrescription ? "Required" : "No"
                }).ToList();

                dgvResults.ClearSelection();
                lblResultCount.Text = $"{_searchResults.Count} medicine(s) found";
            }
            catch (Exception ex)
            {
                HandleException(ex, "Failed to search medicines.");
            }
        }

        private bool TryParseOptionalPrice(string text, out decimal? value)
        {
            value = null;
            if (string.IsNullOrWhiteSpace(text))
            {
                return true;
            }

            if (decimal.TryParse(text.Trim(), out decimal parsed) && parsed >= 0)
            {
                value = parsed;
                return true;
            }

            ShowWarning("Please enter valid numeric values for price range.", "Validation");
            return false;
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvResults.SelectedRows.Count == 0)
            {
                ShowWarning("Please select a medicine from the results first.", "Selection Required");
                return;
            }

            string medId = dgvResults.SelectedRows[0].Cells["Id"].Value?.ToString();
            var medicine = _searchResults.FirstOrDefault(m => m.Id == medId);
            if (medicine == null) return;

            int qty = (int)numQuantity.Value;
            if (!_cartService.AddToCart(medicine, qty, out string error))
            {
                ShowWarning(error, "Cannot Add to Cart");
                return;
            }

            ShowSuccess($"'{medicine.Name}' x {qty} added to cart.", "Added to Cart");
        }

        private void cmbSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsHandleCreated || !EnsureDatabaseAvailable()) return;
            if (_searchResults.Count > 0 || !string.IsNullOrWhiteSpace(txtSearchName.Text) ||
                !string.IsNullOrWhiteSpace(txtSearchCategory.Text))
            {
                PerformSearch();
            }
        }
    }
}
