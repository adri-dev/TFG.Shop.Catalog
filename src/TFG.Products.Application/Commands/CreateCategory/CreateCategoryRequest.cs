using MediatR;

namespace TFG.Products.Application.Commands.CreateCategory
{
    public record CreateCategoryRequest(string Name, string Description) : IRequest<int>;
}
