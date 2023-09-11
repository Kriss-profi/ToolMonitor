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
    public class DealerController : ApiControllerBase
    {
        public DealerController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllDealers([FromQuery] GetDealersRequest request)
        {
            return this.HandleRequest<GetDealersRequest, GetDealersResponse>(request);
        }

        [HttpGet]
        [Route("{dealerId}")]
        public Task<IActionResult> GetDealerById([FromRoute] int dealerId)
        {
            var request = new GetDealerByIdRequest()
            {
                Id = dealerId,
            };
            return this.HandleRequest<GetDealerByIdRequest, GetDealerByIdResponse>(request);
        }


        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddDealer([FromBody] AddDealerRequest request)
        {
            return this.HandleRequest<AddDealerRequest, AddDealerResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> PutDealer([FromBody] PutDealerRequest request)
        {
            return this.HandleRequest<PutDealerRequest, PutDealerResponse>(request);
        }

        [HttpDelete]
        [Route("{dealerId}")]
        public Task<IActionResult> DepeteDealer([FromRoute] int dealerId)
        {
            var request = new DeleteDealerRequest()
            {
                Id = dealerId,
            };
            return this.HandleRequest<DeleteDealerRequest, DeleteDealerResponse>(request);
        }
    }
}
