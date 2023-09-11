using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToolMonitor.ApplicationServices.API.Domain.Models;
using ToolMonitor.ApplicationServices.API.Domain.Users;
using ToolMonitor.DataAccess;

namespace ToolMonitor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ApiControllerBase
    {
        public UserController(IMediator mediator, ILogger<UserController> logger) : base(mediator)
        {
            logger.LogInformation("Wy are in Users");
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllUsers([FromQuery] GetUsersRequest request)
        {
            return this.HandleRequest<GetUsersRequest, GetUsersResponse>(request);
        }

        [HttpGet]
        [Route("{userId}")]
        public Task<IActionResult> GetUserById([FromRoute] int userId)
        {
            var request = new GetUserByIdRequest()
            {
                UserId = userId,
            };
            return this.HandleRequest<GetUserByIdRequest, GetUserByIdResponse>(request);
        }


        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {
            return this.HandleRequest<AddUserRequest, AddUserResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> PutUser([FromBody] PutUserRequest request)
        {
            return this.HandleRequest<PutUserRequest, PutUserResponse>(request);
        }

        [HttpDelete]
        [Route("{userId}")]
        public Task<IActionResult> DepeteUser([FromRoute] int userId)
        {
            var request = new DeleteUserRequest()
            {
                Id = userId,
            };
            return this.HandleRequest<DeleteUserRequest, DeleteUserResponse>(request);
        }
    }
}

