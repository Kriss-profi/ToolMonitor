using Microsoft.AspNetCore.Mvc;
using ToolMonitor.DataAccess;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToolController : ControllerBase
    {
        private readonly IRepository<Tool> toolRepository;

        public ToolController(IRepository<Tool> toolRepository)
        {
            this.toolRepository = toolRepository;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Tool> GetAllTools() => toolRepository.GetAll();
    }
}
