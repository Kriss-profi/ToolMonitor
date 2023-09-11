using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToolMonitor.ApplicationServices.API.Domain.Tools;

namespace ToolMonitor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToolController : ApiControllerBase
    {
        public ToolController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllTools([FromQuery] GetToolsRequest request)
        {
            return this.HandleRequest<GetToolsRequest, GetToolsResponse>(request);
        }

        [HttpGet]
        [Route("{toolId}")]
        public Task<IActionResult> GetToolById([FromRoute] int toolId)
        {
            var request = new GetToolByIdRequest()
            {
                ToolId = toolId,
            };
            return this.HandleRequest<GetToolByIdRequest, GetToolByIdResponse>(request);
        }


        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddTool([FromBody] AddToolRequest request)
        {
            return this.HandleRequest<AddToolRequest, AddToolResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> PutTool([FromBody] PutToolRequest request)
        {
            return this.HandleRequest<PutToolRequest, PutToolResponse>(request);
        }

        [HttpDelete]
        [Route("{toolId}")]
        public Task<IActionResult> DepeteTool([FromRoute] int toolId)
        {
            var request = new DeleteToolRequest()
            {
                Id = toolId,
            };
            return this.HandleRequest<DeleteToolRequest, DeleteToolResponse>(request);
        }
    }
}

