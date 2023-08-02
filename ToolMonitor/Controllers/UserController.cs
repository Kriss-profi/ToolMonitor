using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToolMonitor.ApplicationServices.API.Domain.Models;
using ToolMonitor.DataAccess;

namespace ToolMonitor.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //private readonly IRepository<User> userRepository;

        //public UserController(IRepository<User> userRepository)
        //{
        //    this.userRepository = userRepository;
        //}

        //[HttpGet]
        //[Route("")]
        //public IEnumerable<User> GetAllUsers() => userRepository.GetAll();
    }
}
