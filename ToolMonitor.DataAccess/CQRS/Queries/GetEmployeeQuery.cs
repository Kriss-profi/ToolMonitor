using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess.CQRS.Queries
{
    public class GetEmployeeQuery : QueryBase<Employee>
    {
        public int EmployeeId { get; set; }
        public override async Task<Employee> Execute(ToolStorageContext context)
        {
            return await context.Employees.FirstOrDefaultAsync(x => x.Id == EmployeeId);
        }
    }
}
