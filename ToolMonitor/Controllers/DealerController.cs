using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToolMonitor.DataAccess;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DealerController : ControllerBase
    {
        private readonly IRepository<Dealer> dealerRepository;

        public DealerController(IRepository<Dealer> dealerRepository)
        {
            this.dealerRepository = dealerRepository;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Dealer> GetAllDealers() => dealerRepository.GetAll();
    }
}
