using MongoDB.Bson.Serialization.Attributes;

namespace PharmacySystem.Models
{
    [BsonIgnoreExtraElements]
    public class Customer : User
    {
        [BsonIgnore]
        public string Name
        {
            get => FullName;
            set => FullName = value;
        }
    }
}
