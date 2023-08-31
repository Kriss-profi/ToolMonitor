using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToolMonitor.ApplicationServices.API.Domain.Employees;
using ToolMonitor.DataAccess;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmployeeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllEmployees([FromQuery] GetEmployeesRequest request)
        {
            var response = await this.mediator.Send(request);
            return Ok(response);
        }
    
        [HttpGet]
        [Route("{employeeId}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] int employeeId)
        {
            var request = new GetEmployeeByIdRequest()
            {
                Id = employeeId,
            };
            var response = await this.mediator.Send(request);
            return Ok(response);
        }
    }
}
