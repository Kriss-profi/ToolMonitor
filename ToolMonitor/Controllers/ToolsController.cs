using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToolMonitor.ApplicationServices.API.Domain;

namespace ToolMonitor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ToolsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllTools([FromQuery] GetToolsRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
