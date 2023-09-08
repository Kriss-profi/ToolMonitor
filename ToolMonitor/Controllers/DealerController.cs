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

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddDealer([FromBody] AddDealerRequest request)
        {
            var response = await this.mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> PutDealer([FromBody] PutDealerRequest request)
        {
            var response = await this.mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{dealerId}")]
        public async Task<IActionResult> DeleteDealer([FromRoute] int dealerId)
        {
            var request = new DeleteDealerRequest()
            {
                Id = dealerId,
            };
            var response = await this.mediator.Send(request);
            return Ok(response);
        }
    }
}
