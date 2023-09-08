using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess.CQRS.Commands
{
    public class AddEmployeeCommand : CommandBase<Employee, Employee>
    {
        public override async Task<Employee> Execute(ToolStorageContext context)
        {
            await context.Employees.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
