using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess.CQRS.Commands
{
    public class DeleteToolCommand : CommandBase<Tool, Tool>
    {
        public int Id { get; set; }
        public override async Task<Tool> Execute(ToolStorageContext context)
        {
            var tool = await context.Tools.FirstOrDefaultAsync(x => x.Id == this.Id);
            if (tool != null)
            {
                context.Tools.Remove(tool);
            }
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
