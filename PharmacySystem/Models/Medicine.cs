using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PharmacySystem.Models
{
    [BsonIgnoreExtraElements]
    public class Medicine
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Category")]
        public string Category { get; set; }

        [BsonElement("Price")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }

        [BsonElement("Quantity")]
        public int Quantity { get; set; }

        [BsonElement("ExpiryDate")]
        public DateTime ExpiryDate { get; set; }

        [BsonElement("Dosage")]
        public string Dosage { get; set; }

        [BsonElement("Supplier")]
        public string Supplier { get; set; }

        [BsonElement("DiscountPercentage")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal DiscountPercentage { get; set; }

        [BsonElement("RequiresPrescription")]
        public bool RequiresPrescription { get; set; }
    }
}
