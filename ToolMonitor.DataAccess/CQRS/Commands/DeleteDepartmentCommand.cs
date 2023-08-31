using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess.CQRS.Commands
{
    public class DeleteDepartmentCommand : CommandBase<Department, Department>
    {
        public int Id { get; set; }
        public override async Task<Department> Execute(ToolStorageContext context)
        {
            var department = await context.Departments.FirstOrDefaultAsync(x => x.Id == this.Id);
            if (department != null)
            {
                context.Departments.Remove(department);
            }
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
