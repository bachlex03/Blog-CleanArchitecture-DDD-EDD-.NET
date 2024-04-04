using FluentValidation;

namespace Blog.Application.Product.Command
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.name).NotEmpty();
            RuleFor(p => p.price).NotNull();
            RuleFor(p => p.sku).NotNull();
            RuleFor(p => p.id).NotNull();
        }
    }
}