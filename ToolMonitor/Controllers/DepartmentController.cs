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
    public class DepartmentController : ApiControllerBase
    {

        public DepartmentController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetDepartments([FromQuery] GetDepartmentRequest request)
        {
            return this.HandleRequest< GetDepartmentRequest, GetDepartmentResponse>(request);
        }

        [HttpGet]
        [Route("{departmentId}")]
        public Task<IActionResult> GetDepartmentById([FromRoute] int departmentId)
        {
            var request = new GetDepartmentByIdRequest()
            {
                DepartmentId = departmentId,
            };
            return this.HandleRequest<GetDepartmentByIdRequest, GetDepartmentByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddDepartment([FromBody] AddDepartmentRequest request)
        {
            return this.HandleRequest<AddDepartmentRequest, AddDepartmentResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> PutDepartment([FromBody] PutDepartmentRequest request)
        {
            return this.HandleRequest<PutDepartmentRequest, PutDepartmentResponse>(request);
        }

        [HttpDelete]
        [Route("{departmentId}")]
        public Task<IActionResult> DepeteDepartment([FromRoute] int departmentId)
        {
            var request = new DeleteDepartmentRequest()
            {
                Id = departmentId,
            };
            return this.HandleRequest<DeleteDepartmentRequest, DeleteDepartmentResponse>(request);
        }
    }
}
