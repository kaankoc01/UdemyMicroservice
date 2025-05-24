using UdemyMicroservice.Order.Application.Contracts.Repositories;

namespace UdemyMicroservice.Order.Persistence.Repositories
{
    public class OrderRepository(AppDbContext context) : GenericRepository<Guid,Domain.Entity.Order>(context),IOrderRepository
    {
    }
}
