using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToolMonitor.ApplicationServices.API.Domain.Models;
using ToolMonitor.ApplicationServices.API.Domain.Users;
using ToolMonitor.DataAccess;

namespace ToolMonitor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;
        public UserController(IMediator mediator) //: base(mediator)
        {
            this.mediator = mediator;
        }

        //private readonly IRepository<User> userRepository;

        //public UserController(IRepository<User> userRepository)
        //{
        //    this.userRepository = userRepository;
        //}

        //[HttpGet]
        //[Route("")]
        //public IEnumerable<User> GetAllUsers() => userRepository.GetAll();

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetUserById([FromRoute] int userId)
        {
            var request = new GetUserByIdRequest()
            {
                UserId = userId,
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
