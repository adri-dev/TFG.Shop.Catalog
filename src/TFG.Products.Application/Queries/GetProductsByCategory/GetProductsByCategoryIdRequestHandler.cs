using MediatR;
using TFG.Products.Application.Abstractions.Repositories;
using TFG.Products.Domain.Entities;

namespace TFG.Products.Application.Queries.GetProductsByCategory
{
    public class GetProductsByCategoryIdRequestHandler : IRequestHandler<GetProductsByCategoryIdRequest, GetProductsByCategoryIdResponse>
    {
        private readonly ICategoryReadOnlyRepository _repository;

        public GetProductsByCategoryIdRequestHandler(ICategoryReadOnlyRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetProductsByCategoryIdResponse> Handle(GetProductsByCategoryIdRequest request, CancellationToken cancellationToken)
        {
            var response = new GetProductsByCategoryIdResponse();
            
            var category = await _repository.FirstOrDefaultAsync(c => c.Id == request.CategoryId, nameof(Category.Products));
            if(category == null)
                return response;

            foreach (var product in category.Products)
                response.Add(new ProductEntry(product.Id, product.Name, product.Description, product.Image));

            return response;
        }
    }
}
