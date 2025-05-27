namespace UdemyMicroservice.Order.Application.Contracts.Repositories
{
	public interface IOrderRepository : IGenericRepository<Guid, Domain.Entity.Order>
	{
		Task<List<Domain.Entity.Order>> GetOrderByUserId(Guid buyerId);
	}
}
