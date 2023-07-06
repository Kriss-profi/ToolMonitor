using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess.CQRS.Queries
{
    public class GetToolsQuery : QueryBase<List<Tool>>
    {
        public int Id { get; set; }
        public override Task<List<Tool>> Execute(ToolStorageContext context)
        {
            return context.Tools.ToListAsync();
        }
    }
}
