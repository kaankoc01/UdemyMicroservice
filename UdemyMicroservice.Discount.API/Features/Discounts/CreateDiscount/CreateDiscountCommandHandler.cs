namespace UdemyMicroservice.Discount.API.Features.Discounts.CreateDiscount
{
	public class CreateDiscountCommandHandler(AppDbContext context) : IRequestHandler<CreateDiscountCommand, ServiceResult>
	{
		public async Task<ServiceResult> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
		{
			var hasCodeForUser = await context.DiscountEntities.AnyAsync(x => x.UserId.ToString() == request.UserId.ToString() && x.Code == request.Code, cancellationToken: cancellationToken);

			if (hasCodeForUser)
			{
				return ServiceResult.Error("Discount code already exists for this user","Discount code already exists for this user", HttpStatusCode.BadRequest);
			}


			var discount = new Features.Discounts.DiscountEntity()
			{
				Id = NewId.NextSequentialGuid(),
				Code = request.Code,
				Created = DateTime.Now,
				Rate = request.Rate,
				Expired = request.Expired,
				UserId = request.UserId
			};

			await context.DiscountEntities.AddAsync(discount, cancellationToken);

			await context.SaveChangesAsync(cancellationToken);

			return ServiceResult.SuccessAsNoContent();
		}
	}
}
