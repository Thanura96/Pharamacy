using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PharmacySystem.Models
{
    [BsonIgnoreExtraElements]
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string OrderId { get; set; }

        [BsonElement("CustomerId")]
        public string CustomerId { get; set; }

        [BsonElement("CustomerName")]
        public string CustomerName { get; set; }

        [BsonElement("OrderDate")]
        public DateTime OrderDate { get; set; }

        [BsonElement("TotalAmount")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal TotalAmount { get; set; }

        [BsonElement("OrderStatus")]
        [BsonRepresentation(BsonType.String)]
        public OrderStatus OrderStatus { get; set; }

        [BsonElement("PrescriptionPath")]
        public string PrescriptionPath { get; set; }

        [BsonElement("DiscountApplied")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal DiscountApplied { get; set; }

        [BsonElement("Items")]
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
