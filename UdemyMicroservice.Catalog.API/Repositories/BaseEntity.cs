using MongoDB.Bson.Serialization.Attributes;
namespace UdemyMicroservice.Catalog.API.Repositories
{
    public class BaseEntity
    {
        // snow flakes
        [BsonElement("_id")]
        public Guid Id { get; set; }
    }
}
