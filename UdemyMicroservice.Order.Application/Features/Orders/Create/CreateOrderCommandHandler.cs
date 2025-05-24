using MediatR;
using UdemyMicroservice.Order.Application.Contracts.Repositories;
using UdemyMicroservice.Order.Application.Contracts.UnitOfWorks;
using UdemyMicroservice.Order.Domain.Entity;
using UdemyMicroservice.Shared;
using UdemyMicroservice.Shared.Services;

namespace UdemyMicroservice.Order.Application.Features.Orders.Create
{
	public class CreateOrderCommandHandler(IOrderRepository orderRepository,IGenericRepository<int,Address> addressRepository,IIdentityService identityService,IUnitOfWork unitOfWork) : IRequestHandler<CreateOrderCommand, ServiceResult>
	{
		public async Task<ServiceResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
		{
			if(!request.Items.Any())
			{
				return ServiceResult.Error("Order items not found", "Order items are required", System.Net.HttpStatusCode.BadRequest);
			}

			
			var newAddress = new Domain.Entity.Address
			{
				Province = request.Address.Province,
				District = request.Address.District,
				Street = request.Address.Street,
				ZipCode = request.Address.ZipCode,
				Line = request.Address.Line,
			};


			var order = Domain.Entity.Order.CreateUnPaidOrder(identityService.GetUserId, request.discountRate, newAddress.Id);

			foreach (var orderItem in request.Items)
			{
				order.AddOrderItem(orderItem.ProductId, orderItem.ProductName, orderItem.UnitPrice);
			}

			order.Address = newAddress;

			orderRepository.Add(order);
			await unitOfWork.CommitAsync(cancellationToken);

			var paymentId = Guid.Empty;
			
			// payment işlemleri

			order.SetPaidStatus(paymentId);

			orderRepository.Update(order);
			await unitOfWork.CommitAsync(cancellationToken);


			return ServiceResult.SuccessAsNoContent();
		}
	}
}
