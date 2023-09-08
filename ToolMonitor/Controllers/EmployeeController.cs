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


        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeRequest request)
        {
            var response = await this.mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> PutEmployee([FromBody] PutEmployeeRequest request)
        {
            var response = await this.mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{EmployeeId}")]
        public async Task<IActionResult> DepeteEmployee([FromRoute] int EmployeeId)
        {
            var request = new DeleteEmployeeRequest()
            {
                Id = EmployeeId,
            };
            var response = await this.mediator.Send(request);
            return Ok(response);
        }
    }
}
