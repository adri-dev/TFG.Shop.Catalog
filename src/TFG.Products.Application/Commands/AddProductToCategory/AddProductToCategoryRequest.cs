using MediatR;

namespace TFG.Products.Application.Commands.AddProductToCategory
{
    public record AddProductToCategoryRequest(int CategoryId, string Name, string Description, string Image) : IRequest<int>;
}
