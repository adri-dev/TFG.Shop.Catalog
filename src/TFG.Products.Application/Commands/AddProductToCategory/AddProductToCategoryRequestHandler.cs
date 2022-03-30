using MediatR;
using TFG.Products.Application.Abstractions.Repositories;
using TFG.Products.Domain;

namespace TFG.Products.Application.Commands.AddProductToCategory
{
    public class AddProductToCategoryRequestHandler : IRequestHandler<AddProductToCategoryRequest, int>
    {
        private readonly ICategoryRepository _repository;

        public AddProductToCategoryRequestHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(AddProductToCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _repository.FirstOrDefaultAsync(c => c.Id == request.CategoryId)
                ?? throw new DomainException($"Category wirh Id {request.CategoryId} does not exist");

            var product = category.AddProduct(request.Name, request.Description, request.Image);

            await _repository.SaveChangesAsync();

            return product.Id;
        }
    }
}
