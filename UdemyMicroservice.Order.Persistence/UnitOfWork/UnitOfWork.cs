using UdemyMicroservice.Order.Application.Contracts.UnitOfWorks;

namespace UdemyMicroservice.Order.Persistence.UnitOfWork
{
	public class UnitOfWork(AppDbContext context) : IUnitOfWork
	{
		public async Task BeginTransactionAsync(CancellationToken cancellationToken)
		{
			await context.Database.BeginTransactionAsync(cancellationToken);
		}
		public Task<int> CommitAsync(CancellationToken cancellationToken = default)
		{
			return context.SaveChangesAsync(cancellationToken);
		}
		public Task CommitTransactionAsync(CancellationToken cancellationToken)
		{
			return context.Database.CommitTransactionAsync(cancellationToken);
		}
	}
}
