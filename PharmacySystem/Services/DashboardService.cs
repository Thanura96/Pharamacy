using System.Linq;
using PharmacySystem.Models;
using PharmacySystem.Repositories;
using PharmacySystem.Services.Interfaces;

namespace PharmacySystem.Services
{
    public class DashboardSummary
    {
        public decimal TotalSales { get; set; }
        public int TotalMedicines { get; set; }
        public int LowStockMedicines { get; set; }
        public int ActiveOrders { get; set; }
    }

    public class DashboardService
    {
        private readonly MedicineService _medicineService;
        private readonly IOrderRepository _orderRepository;
        private readonly IInventoryService _inventoryService;
        private readonly SaleService _saleService;

        public DashboardService(
            MedicineService medicineService,
            IOrderRepository orderRepository,
            IInventoryService inventoryService,
            SaleService saleService)
        {
            _medicineService = medicineService;
            _orderRepository = orderRepository;
            _inventoryService = inventoryService;
            _saleService = saleService;
        }

        public DashboardSummary GetSummary()
        {
            var medicines = _medicineService.GetAllMedicines();
            var orders = _orderRepository.GetAllOrders();
            var sales = _saleService.GetAllSales();
            var lowStock = _inventoryService.CheckLowStock();

            decimal orderRevenue = orders.Sum(o => o.TotalAmount);
            decimal saleRevenue = sales.Sum(s => s.TotalAmount);

            int activeOrders = orders.Count(o =>
                o.OrderStatus == OrderStatus.Pending ||
                o.OrderStatus == OrderStatus.ReadyForPickup);

            return new DashboardSummary
            {
                TotalSales = orderRevenue + saleRevenue,
                TotalMedicines = medicines.Count,
                LowStockMedicines = lowStock.Count,
                ActiveOrders = activeOrders
            };
        }
    }
}
