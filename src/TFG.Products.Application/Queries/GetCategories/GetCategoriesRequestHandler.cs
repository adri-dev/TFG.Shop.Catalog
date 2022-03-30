using MediatR;
using TFG.Products.Application.Abstractions.Repositories;

namespace TFG.Products.Application.Queries.GetCategories
{
    public class GetCategoriesRequestHandler : IRequestHandler<GetCategoriesRequest, GetCategoriesResponse>
    {
        private readonly ICategoryReadOnlyRepository _repository;

        public GetCategoriesRequestHandler(ICategoryReadOnlyRepository repository)
        {
            _repository = repository;
        }

        async Task<GetCategoriesResponse> IRequestHandler<GetCategoriesRequest, GetCategoriesResponse>.Handle(GetCategoriesRequest request, CancellationToken cancellationToken)
        {
            var categories = await _repository.GetAllAsync();

            var response = new GetCategoriesResponse();
            foreach (var category in categories)
                response.Add(new CategoryEntry(category.Id, category.Name, category.Description));

            return response;
        }
    }
}
