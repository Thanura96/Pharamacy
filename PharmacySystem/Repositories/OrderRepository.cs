using System.Collections.Generic;
using MongoDB.Driver;
using PharmacySystem.Database;
using PharmacySystem.Models;

namespace PharmacySystem.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MongoDbContext _context;

        public OrderRepository(MongoDbContext context)
        {
            _context = context;
        }

        public void AddOrder(Order order)
        {
            _context.Orders.InsertOne(order);
        }

        public List<Order> GetAllOrders()
        {
            return _context.Orders.Find(_ => true).ToList();
        }

        public List<Order> GetOrdersByCustomer(string customerId)
        {
            var filter = Builders<Order>.Filter.Eq(o => o.CustomerId, customerId);
            return _context.Orders.Find(filter).ToList();
        }

        public void UpdateOrderStatus(string orderId, OrderStatus status)
        {
            var filter = Builders<Order>.Filter.Eq(o => o.OrderId, orderId);
            var update = Builders<Order>.Update.Set(o => o.OrderStatus, status);
            _context.Orders.UpdateOne(filter, update);
        }

        public Order GetOrderById(string orderId)
        {
            var filter = Builders<Order>.Filter.Eq(o => o.OrderId, orderId);
            return _context.Orders.Find(filter).FirstOrDefault();
        }
    }
}
