using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToolMonitor.ApplicationServices.API.Domain.Dealers;
using ToolMonitor.DataAccess;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DealerController : ControllerBase
    {
        private readonly IMediator mediator;

        public DealerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllDealers([FromQuery] GetDealersRequest request)
        {
            var response = await this.mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("{dealerId}")]
        public async Task<IActionResult> GetDealerById([FromRoute] int dealerId)
        {
            var request = new GetDealerByIdRequest()
            {
                Id = dealerId
            };
            var response = await this.mediator.Send(request);
            return Ok(response);
        }
    }
}
