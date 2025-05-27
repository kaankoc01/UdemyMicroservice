using Microsoft.EntityFrameworkCore;
using UdemyMicroservice.Order.Application.Contracts.Repositories;
using UdemyMicroservice.Order.Domain.Entity;

namespace UdemyMicroservice.Order.Persistence.Repositories
{
	public class OrderRepository(AppDbContext context) : GenericRepository<Guid, Domain.Entity.Order>(context), IOrderRepository
	{
		public Task<List<Domain.Entity.Order>> GetOrderByUserId(Guid buyerId)
		{
			return context.Orders.Include(x => x.OrderItems).Where(x => x.BuyerId == buyerId).OrderByDescending(x => x.Created).ToListAsync();
		}
	}
}
