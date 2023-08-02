using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess.CQRS.Queries
{
    public class GetEmployeesQuery : QueryBase<List<Employee>>
    {
        public int CompanyId { get; set; }
        public override async Task<List<Employee>> Execute(ToolStorageContext context)
        {
            return await context.Employees.Where(x => x.CompanyId == CompanyId).ToListAsync();
        }
    }
}
