using FluentValidation;

namespace UdemyMicroservice.Order.Application.Features.Orders.Create
{
	public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
	{
		public CreateOrderCommandValidator()
		{

			RuleFor(x => x.DiscountRate)
				.GreaterThanOrEqualTo(0).When(x => x.DiscountRate.HasValue)
				.WithMessage("{PropertyName} must be a positive number or zero");

			RuleFor(x => x.Address)
				.NotNull()
				.WithMessage("{PropertyName} is required")
				.SetValidator(new AddressDtoValidator());

			RuleFor(x => x.Payment)
				.NotNull()
				.WithMessage("{PropertyName} cannot be null")
				.SetValidator(new PaymentDtoValidator());

			RuleFor(x => x.Items)
				.NotEmpty()
				.WithMessage("{PropertyName} must be contain at least one order item");

			RuleForEach(x => x.Items)
				.SetValidator(new OrderItemDtoValidator());
		}
	}
	public class AddressDtoValidator : AbstractValidator<AddressDto>
	{
		public AddressDtoValidator()
		{
			RuleFor(x => x.Province)
				.NotEmpty()
				.WithMessage("{PropertyName} is required");
			RuleFor(x => x.District)
				.NotEmpty()
				.WithMessage("{PropertyName} is required");
			RuleFor(x => x.Street)
				.NotEmpty()
				.WithMessage("{PropertyName} is required");
			RuleFor(x => x.ZipCode)
				.NotEmpty()
				.WithMessage("{PropertyName} is required");
			RuleFor(x => x.Line)
				.NotEmpty()
				.WithMessage("{PropertyName} is required");
		}
	}
	public class PaymentDtoValidator : AbstractValidator<PaymentDto>
	{
		public PaymentDtoValidator()
		{
			RuleFor(x => x.CardNumber)
				.NotEmpty()
				.WithMessage("{PropertyName} is required");
			RuleFor(x => x.CardHolderName)
				.NotEmpty()
				.WithMessage("{PropertyName} is required");
			RuleFor(x => x.Expiration)
				.NotEmpty()
				.WithMessage("{PropertyName} is required");
			RuleFor(x => x.Cvc)
				.NotEmpty()
				.WithMessage("{PropertyName} is required");
			RuleFor(x => x.Amount)
				.GreaterThan(0)
				.WithMessage("{PropertyName} must be greater than zero");
		}
	}
	public class OrderItemDtoValidator : AbstractValidator<OrderItemDto>
	{
		public OrderItemDtoValidator()
		{
			RuleFor(x => x.ProductId)
				.NotEmpty()
				.WithMessage("{PropertyName} is required");
			RuleFor(x => x.ProductName)
				.NotEmpty()
				.WithMessage("{PropertyName} is required");
			RuleFor(x => x.UnitPrice)
				.GreaterThan(0)
				.WithMessage("{PropertyName} must be greater than zero");
		}
	}


}
