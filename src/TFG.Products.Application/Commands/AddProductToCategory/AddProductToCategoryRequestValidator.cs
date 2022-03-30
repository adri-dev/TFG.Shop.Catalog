using FluentValidation;

namespace TFG.Products.Application.Commands.AddProductToCategory
{
    public class AddProductToCategoryRequestValidator : AbstractValidator<AddProductToCategoryRequest>
    {
        public AddProductToCategoryRequestValidator()
        {
            RuleFor(c => c.CategoryId).GreaterThan(0);
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
        }
    }
}
