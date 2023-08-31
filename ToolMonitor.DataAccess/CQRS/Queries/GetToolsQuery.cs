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
        public string ToolName { get; set; }
        public int CompanyId { get; set; }


        public override async Task<List<Tool>> Execute(ToolStorageContext context)
        {

            if (ToolName == null)
            {
                return await context.Tools.Where(x => x.CompanyId == CompanyId).ToListAsync();
            }
            else
            {
                return await context.Tools
                    .Where(x => x.ToolName.Contains(ToolName))
                    .Where(x => x.ToolDescription.Contains(ToolName))
                    .Where(x => x.CompanyId == CompanyId)
                    .ToListAsync();
            }
        }
    }
}
