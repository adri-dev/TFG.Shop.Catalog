using MediatR;
using Microsoft.AspNetCore.Mvc;
using TFG.Products.Application.Commands.AddProductToCategory;
using TFG.Products.Application.Queries.GetProductsByCategory;

namespace TFG.Products.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ByCategory/{categoryId}")]
        public async Task<ActionResult> GetProductsByCategory(int categoryId)
        {
            var response = await _mediator.Send(new GetProductsByCategoryIdRequest(categoryId));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> AddProductToCategory(AddProductToCategoryRequest request)
        {
            var response = await _mediator.Send(request);

            return Created("", new { Id = response });
        }
    }
}
