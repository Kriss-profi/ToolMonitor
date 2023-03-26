using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToolMonitor.DataAccess;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        public readonly IRepository<Department> departmentReposytory;

        public DepartmentController(IRepository<Department> departmentReposytory)
        {
            this.departmentReposytory = departmentReposytory;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Department> GetAllDepartments() => departmentReposytory.GetAll();
    }
}
