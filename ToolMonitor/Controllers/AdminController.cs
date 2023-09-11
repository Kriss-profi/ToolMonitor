using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToolMonitor.ApplicationServices.API.Domain.Users;

namespace ToolMonitor.Controllers
{
    [ApiController]
    [Route("admin/[controller]")]
    public class AdminController : ApiControllerBase
    {
        public AdminController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersRequest request)
        {
            return this.HandleRequest<GetAllUsersRequest, GetAllUsersResponse>(request);
        }
    }
}
