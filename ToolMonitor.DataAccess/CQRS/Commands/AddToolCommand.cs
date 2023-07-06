using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess.CQRS.Commands
{
    public class AddToolCommand : CommandBase<Tool, Tool>
    {
        public override async Task<Tool> Execute(ToolStorageContext context)
        {
            await context.Tools.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
