using FluentValidation;

namespace UdemyMicroservice.Basket.API.Features.Baskets.AddBasketItem
{
    public class AddBasketItemCommandValidator : AbstractValidator<AddBasketItemCommand>
    {
        public AddBasketItemCommandValidator()
        {
            RuleFor(x => x.CourseId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.");
            RuleFor(x => x.CourseName)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.");
            RuleFor(x => x.CoursePrice)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero");
            RuleFor(x => x.ImageUrl)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.");
        }
    }
}
