using MediatR;
using TFG.Products.Application.Abstractions.Repositories;
using TFG.Products.Domain;
using TFG.Products.Domain.Entities;

namespace TFG.Products.Application.Commands.CreateCategory
{
    public class CreateCategoryRequestHandler : IRequestHandler<CreateCategoryRequest, int>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryRequestHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<int> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.FirstOrDefaultAsync(c => c.Name == request.Name);

            if (category != null)
                throw new DomainException($"Category with name {request.Name} already exists");

            var newCategory = new Category(request.Name, request.Description);

            await _categoryRepository.AddAsync(newCategory);
            await _categoryRepository.SaveChangesAsync();

            return newCategory.Id;
        }
    }
}
