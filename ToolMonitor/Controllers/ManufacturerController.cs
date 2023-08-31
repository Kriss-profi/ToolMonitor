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
    }
}
