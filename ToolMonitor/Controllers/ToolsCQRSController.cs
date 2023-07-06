using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Http;
using ToolMonitor.ApplicationServices.API.Domain;

namespace ToolMonitor.Controllers
{

    [Route("apicostam/[controller]")]
    [ApiController]
    public class ToolsCQRSController : ControllerBase
    {
        private readonly IMediator mediator;

        public ToolsCQRSController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllTools([FromQuery] GetToolsCQRSRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
