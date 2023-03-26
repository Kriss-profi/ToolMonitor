using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToolMonitor.DataAccess;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IRepository<Manufacturer> manufacturerRepository;

        public ManufacturerController(IRepository<Manufacturer> manufacturerRepository)
        {
            this.manufacturerRepository = manufacturerRepository;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Manufacturer> GetAllManufacturers() => manufacturerRepository.GetAll();
    }
}
