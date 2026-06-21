using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PharmacySystem.Models
{
    public class OrderItem
    {
        [BsonElement("MedicineId")]
        public string MedicineId { get; set; }

        [BsonElement("MedicineName")]
        public string MedicineName { get; set; }

        [BsonElement("Quantity")]
        public int Quantity { get; set; }

        [BsonElement("UnitPrice")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal UnitPrice { get; set; }

        [BsonElement("SubTotal")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal SubTotal { get; set; }
    }
}
