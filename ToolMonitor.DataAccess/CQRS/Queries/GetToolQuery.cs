using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess.CQRS.Queries
{
    public class GetToolQuery : QueryBase<Tool>
    {
        public int Id { get; set; }
        public override async Task<Tool> Execute(ToolStorageContext context)
        {
            var tool = await context.Tools.FirstOrDefaultAsync(x => x.Id == this.Id);
            return tool;
        }
    }
}
