using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToolMonitor.ApplicationServices.API.Domain.Categories;
using ToolMonitor.DataAccess;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ApiControllerBase
    {
        public CategoryController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllCategories([FromQuery] GetCategoryRequest request)
        {
            return this.HandleRequest<GetCategoryRequest, GetCategoryResponse>(request);
        }

        [HttpGet]
        [Route("{categoryId}")]
        public Task<IActionResult> GetCategoryById([FromRoute] int categoryId)
        {
            var request = new GetCategoryByIdRequest()
            {
                Id = categoryId,
            };
            return this.HandleRequest<GetCategoryByIdRequest, GetCategoryByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddCategory([FromBody] AddCategoryRequest request)
        {
            return this.HandleRequest<AddCategoryRequest, AddCategoryResponse>(request);


            //var response = await this.mediator.Send(request);
            //return Ok(response);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> PutCategory([FromBody] PutCategoryRequest request)
        {
            return this.HandleRequest<PutCategoryRequest, PutCategoryResponse>(request);
        }

        [HttpDelete]
        [Route("{categoryId}")]
        public Task<IActionResult> DeleteCategory([FromRoute] int categoryId)
        {
            var request = new DeleteCategoryRequest()
            {
                CategoryId = categoryId,
            };
            return this.HandleRequest<DeleteCategoryRequest, DeleteCategoryResponse>(request);
        }

    }
}
