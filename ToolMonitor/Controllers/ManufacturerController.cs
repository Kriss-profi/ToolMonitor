using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToolMonitor.ApplicationServices.API.Domain.Manufacturers;
using ToolMonitor.DataAccess;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ManufacturerController : ApiControllerBase
    {
        public ManufacturerController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllManufacturers([FromQuery] GetManufacturersRequest request)
        {
            return this.HandleRequest<GetManufacturersRequest, GetManufacturersResponse>(request);
        }

        [HttpGet]
        [Route("{manufacturerId}")]
        public Task<IActionResult> GetManufacturerById([FromRoute] int manufacturerId)
        {
            var request = new GetManufacturerByIdRequest()
            {
                ManufacturerId = manufacturerId,
            };
            return this.HandleRequest<GetManufacturerByIdRequest, GetManufacturerByIdResponse>(request);
        }


        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddManufacturer([FromBody] AddManufacturerRequest request)
        {
            return this.HandleRequest<AddManufacturerRequest, AddManufacturerResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> PutManufacturer([FromBody] PutManufacturerRequest request)
        {
            return this.HandleRequest<PutManufacturerRequest, PutManufacturerResponse>(request);
        }

        [HttpDelete]
        [Route("{ManufacturerId}")]
        public  Task<IActionResult> DepeteManufacturer([FromRoute] int ManufacturerId)
        {
            var request = new DeleteManufacturerRequest()
            {
                Id = ManufacturerId,
            };
            return this.HandleRequest<DeleteManufacturerRequest, DeleteManufacturerResponse>(request);
        }
    }
}
