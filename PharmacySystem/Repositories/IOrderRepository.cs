using System.Collections.Generic;
using PharmacySystem.Models;

namespace PharmacySystem.Repositories
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);
        List<Order> GetAllOrders();
        List<Order> GetOrdersByCustomer(string customerId);
        void UpdateOrderStatus(string orderId, OrderStatus status);
        Order GetOrderById(string orderId);
    }
}
