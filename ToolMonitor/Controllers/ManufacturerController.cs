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
    public class ManufacturerController : ControllerBase
    {
        private readonly IMediator mediator;

        public ManufacturerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllManufacturers([FromQuery] GetManufacturersRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("{manufacturerId}")]
        public async Task<IActionResult> GetManufacturerById([FromRoute] int manufacturerId)
        {
            var request = new GetManufacturerByIdRequest()
            {
                ManufacturerId = manufacturerId,
            };
            var response = await mediator.Send(request);
            return Ok(response);
        }


        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddManufacturer([FromBody] AddManufacturerRequest request)
        {
            var response = await this.mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> PutManufacturer([FromBody] PutManufacturerRequest request)
        {
            var response = await this.mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{ManufacturerId}")]
        public async Task<IActionResult> DepeteManufacturer([FromRoute] int ManufacturerId)
        {
            var request = new DeleteManufacturerRequest()
            {
                Id = ManufacturerId,
            };
            var response = await this.mediator.Send(request);
            return Ok(response);
        }
    }
}
