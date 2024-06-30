using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB_OData.Entities
{
    public class Customer
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name"), BsonRepresentation(BsonType.String)]
        public string? Name { get; set; }

        [BsonElement("email"),  BsonRepresentation(BsonType.String)]
        public string? Email { get; set; }

        [BsonElement("address"),  BsonRepresentation(BsonType.String)]
        public string? Address { get; set; }

        [BsonElement("numberOfItems"),  BsonRepresentation(BsonType.Int32)]
        public int? NumberOfItems { get; set; }
    }
}
