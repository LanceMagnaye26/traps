using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TrapApi.Models
{
    public class Trap
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("TrapType")]
        public string TrapType { get; set; }

        [BsonElement("Timestamp")]
        public BsonDateTime Timestamp { get; set; }

        [BsonElement("Location")]
        public string Location { get; set; }

        [BsonElement("AmountOfBait")]
        public decimal AmountOfBait { get; set; }
    }
}