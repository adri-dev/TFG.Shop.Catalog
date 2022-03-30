using MediatR;

namespace TFG.Products.Application.Queries.GetProductsByCategory
{
    public record GetProductsByCategoryIdRequest(int CategoryId) : IRequest<GetProductsByCategoryIdResponse>;
}
