using System;
using System.Collections.Generic;
using System.Linq;
using PharmacySystem.Models;
using PharmacySystem.Repositories;
using PharmacySystem.Services.Interfaces;

namespace PharmacySystem.Services
{
    public class ReportService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMedicineRepository _medicineRepository;
        private readonly IInventoryService _inventoryService;
        private readonly SaleService _saleService;

        public ReportService(
            IOrderRepository orderRepository,
            ICustomerRepository customerRepository,
            IMedicineRepository medicineRepository,
            IInventoryService inventoryService,
            SaleService saleService)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _medicineRepository = medicineRepository;
            _inventoryService = inventoryService;
            _saleService = saleService;
        }

        public decimal GetTotalOrderRevenue()
        {
            return _orderRepository.GetAllOrders().Sum(o => o.TotalAmount);
        }

        public int GetTotalOrderCount()
        {
            return _orderRepository.GetAllOrders().Count;
        }

        public List<object> GetSalesByDate()
        {
            var orderRows = _orderRepository.GetAllOrders()
                .GroupBy(o => o.OrderDate.Date)
                .Select(g => new
                {
                    Date = g.Key.ToShortDateString(),
                    Orders = g.Count(),
                    Revenue = g.Sum(o => o.TotalAmount).ToString("F2"),
                    Source = "Orders"
                });

            var saleRows = _saleService.GetAllSales()
                .GroupBy(s => s.SaleDate.Date)
                .Select(g => new
                {
                    Date = g.Key.ToShortDateString(),
                    Orders = g.Count(),
                    Revenue = g.Sum(s => s.TotalAmount).ToString("F2"),
                    Source = "Legacy Sales"
                });

            return orderRows.Concat(saleRows)
                .OrderByDescending(r => r.Date)
                .Cast<object>()
                .ToList();
        }

        public List<object> GetCurrentStockReport()
        {
            return _medicineRepository.GetAll()
                .OrderBy(m => m.Name)
                .Select(m => new
                {
                    m.Name,
                    m.Category,
                    m.Quantity,
                    Price = m.Price.ToString("F2"),
                    Discount = $"{m.DiscountPercentage:F0}%",
                    ExpiryDate = m.ExpiryDate.ToShortDateString(),
                    Status = m.Quantity < InventoryService.LowStockThreshold ? "Low Stock" : "OK"
                })
                .Cast<object>()
                .ToList();
        }

        public List<object> GetLowStockReport()
        {
            return _inventoryService.CheckLowStock()
                .Select(m => new
                {
                    m.Name,
                    m.Category,
                    m.Quantity,
                    Threshold = InventoryService.LowStockThreshold,
                    ExpiryDate = m.ExpiryDate.ToShortDateString()
                })
                .Cast<object>()
                .ToList();
        }

        public List<object> GetCustomerOrderHistory()
        {
            var orders = _orderRepository.GetAllOrders();
            var customers = _customerRepository.GetAll();

            return customers.Select(c =>
            {
                var customerOrders = orders.Where(o => o.CustomerId == c.Id).ToList();
                return new
                {
                    CustomerName = c.FullName,
                    c.Email,
                    c.Phone,
                    TotalOrders = customerOrders.Count,
                    TotalSpent = customerOrders.Sum(o => o.TotalAmount).ToString("F2"),
                    LastOrderDate = customerOrders.Count > 0
                        ? customerOrders.Max(o => o.OrderDate).ToString("g")
                        : "—"
                };
            })
            .OrderByDescending(x => x.TotalOrders)
            .Cast<object>()
            .ToList();
        }
    }
}
