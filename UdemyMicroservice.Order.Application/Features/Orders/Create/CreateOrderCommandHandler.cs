using MediatR;
using UdemyMicroservice.Order.Application.Contracts.Repositories;
using UdemyMicroservice.Order.Domain.Entity;
using UdemyMicroservice.Shared;
using UdemyMicroservice.Shared.Services;

namespace UdemyMicroservice.Order.Application.Features.Orders.Create
{
	public class CreateOrderCommandHandler(IGenericRepository<Guid,Domain.Entity.Order> orderRepository,IGenericRepository<int,Address> addressRepository,IIdentityService identityService) : IRequestHandler<CreateOrderCommand, ServiceResult>
	{
		public Task<ServiceResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
		{
			if(!request.Items.Any())
			{
				return Task.FromResult(ServiceResult.Error("Order items not found", "Order items are required", System.Net.HttpStatusCode.BadRequest));
			}


			var newAddress = new Domain.Entity.Address
			{
				Province = request.Address.Province,
				District = request.Address.District,
				Street = request.Address.Street,
				ZipCode = request.Address.ZipCode,
				Line = request.Address.Line,
			};

			addressRepository.Add(newAddress);
			// unitofwork.SaveChangesAsync();

			var order = Domain.Entity.Order.CreateUnPaidOrder(identityService.GetUserId, request.discountRate, newAddress.Id);

			foreach (var orderItem in request.Items)
			{
				order.AddOrderItem(orderItem.ProductId, orderItem.ProductName, orderItem.UnitPrice);
			}
			orderRepository.Add(order);
			// unitofwork.SaveChangesAsync();

			var paymentId = Guid.Empty;
			// payment işlemleri burada yapılacak

			order.SetPaidStatus(paymentId);

			orderRepository.Update(order);
			// unitofwork.SaveChangesAsync();
			return Task.FromResult(ServiceResult.SuccessAsNoContent());
		}
	}
}
