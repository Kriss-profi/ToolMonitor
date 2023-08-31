using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToolMonitor.ApplicationServices.API.Domain.Departments;
using ToolMonitor.DataAccess;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator mediator;

        public DepartmentController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetDepartments([FromQuery] GetDepartmentRequest request)
        {
            var response = await this.mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("{departmentId}")]
        public async Task<IActionResult> GetDepartmentById([FromRoute] int departmentId)
        {
            var query = new GetDepartmentByIdRequest()
            {
                DepartmentId = departmentId,
            };
            var response = await this.mediator.Send(query);
            return Ok(response);
        }
    }
}
