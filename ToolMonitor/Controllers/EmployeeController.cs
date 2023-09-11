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
    public class EmployeeController : ApiControllerBase
    {
        public EmployeeController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllEmployees([FromQuery] GetEmployeesRequest request)
        {
            return this.HandleRequest<GetEmployeesRequest, GetEmployeesResponse>(request);
        }
    
        [HttpGet]
        [Route("{employeeId}")]
        public Task<IActionResult> GetEmployeeById([FromRoute] int employeeId)
        {
            var request = new GetEmployeeByIdRequest()
            {
                Id = employeeId,
            };
            return this.HandleRequest<GetEmployeeByIdRequest, GetEmployeeByIdResponse>(request);
        }


        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddEmployee([FromBody] AddEmployeeRequest request)
        {
            return this.HandleRequest<AddEmployeeRequest, AddEmployeeResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> PutEmployee([FromBody] PutEmployeeRequest request)
        {
            return this.HandleRequest<PutEmployeeRequest, PutEmployeeResponse>(request);
        }

        [HttpDelete]
        [Route("{EmployeeId}")]
        public Task<IActionResult> DepeteEmployee([FromRoute] int EmployeeId)
        {
            var request = new DeleteEmployeeRequest()
            {
                Id = EmployeeId,
            };

            return this.HandleRequest<DeleteEmployeeRequest, DeleteEmployeeResponse>(request);
        }
    }
}
