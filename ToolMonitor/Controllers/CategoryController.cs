using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToolMonitor.DataAccess;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IRepository<Category> categoryRepository;

        public CategoryController(IRepository<Category> categoryRepository, IMediator mediator)
        {
            this.categoryRepository = categoryRepository;
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Category> GetAllTools() => categoryRepository.GetAll();

        [HttpGet]
        [Route("{categoryId}")]
        public Category GetCategoryById(int categoryId) => categoryRepository.GetById(categoryId);
    }
}
