
namespace UdemyMicroservice.Discount.API.Repositories
{
	public class BaseEntity
	{
		// snow flakes
		[BsonElement("_id")] public Guid Id { get; set; }
	}
}
