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


        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddTool([FromBody] AddToolRequest request)
        {
            var response = await this.mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> PutTool([FromBody] PutToolRequest request)
        {
            var response = await this.mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{ToolId}")]
        public async Task<IActionResult> DepeteTool([FromRoute] int ToolId)
        {
            var request = new DeleteToolRequest()
            {
                Id = ToolId,
            };
            var response = await this.mediator.Send(request);
            return Ok(response);
        }
    }
}
