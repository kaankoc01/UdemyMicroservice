namespace UdemyMicroservice.Order.Application.Contracts.UnitOfWorks
{
	public interface IUnitOfWork
	{
		Task<int> CommitAsync(CancellationToken cancellationToken =default);
		Task BeginTransactionAsync(CancellationToken cancellationToken);
		Task CommitTransactionAsync(CancellationToken cancellationToken);
	}
}
