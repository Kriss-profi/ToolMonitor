using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToolMonitor.ApplicationServices.API.Domain.Tools;

namespace ToolMonitor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToolController : ControllerBase
    {
        private readonly IMediator mediator;

        public ToolController(IMediator mediator)
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

        [HttpGet]
        [Route("{toolId}")]
        public async Task<IActionResult> GetToolsById([FromRoute] int toolId)
        {
            var request = new GetToolByIdRequest()
            {
                ToolId = toolId,
            };
            var response = await mediator.Send(request);
            return Ok(response);
        }

    }
}
