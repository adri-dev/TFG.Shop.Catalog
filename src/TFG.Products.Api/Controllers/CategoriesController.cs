using MediatR;
using Microsoft.AspNetCore.Mvc;
using TFG.Products.Application.Commands.CreateCategory;
using TFG.Products.Application.Queries.GetCategories;

namespace TFG.Products.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            var response = await _mediator.Send(new GetCategoriesRequest());

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory(CreateCategoryRequest request)
        {
            var response = await _mediator.Send(request);

            return Created("", new { Id = response });
        }
    }
}