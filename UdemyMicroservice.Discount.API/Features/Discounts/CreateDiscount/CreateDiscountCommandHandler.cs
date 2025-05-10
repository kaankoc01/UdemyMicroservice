using UdemyMicroservice.Shared.Services;

namespace UdemyMicroservice.Discount.API.Features.Discounts.CreateDiscount
{
	public class CreateDiscountCommandHandler(AppDbContext context, IIdentityService identityService) : IRequestHandler<CreateDiscountCommand, ServiceResult>
	{

		public async Task<ServiceResult> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
		{
			var discount = new Features.Discounts.DiscountEntity()
			{
				Id = NewId.NextSequentialGuid(),
				Code = request.Code,
				Rate = request.Rate,
				Created = DateTime.Now,
				UserId = identityService.GetUserId,
				Expired = request.Expired
			};
			context.DiscountEntities.AddAsync(discount, cancellationToken);
			await context.SaveChangesAsync(cancellationToken);
			return ServiceResult.SuccessAsNoContent();
		}
	}
}
