using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess.CQRS.Commands
{
    public class DeleteEmployeeCommand : CommandBase<Employee, Employee>
    {
        public int Id  { get; set; }
        public override async Task<Employee> Execute(ToolStorageContext context)
        {
            var employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == this.Id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
            }
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
