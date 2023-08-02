using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess.CQRS.Queries
{
    public class GetDepartmentQuery : QueryBase<Department>
    {
        public int Id { get; set; }
        public override async Task<Department> Execute(ToolStorageContext context)
        {
            return await context.Departments.FirstOrDefaultAsync(x => x.Id == this.Id);
        }
    }
}
