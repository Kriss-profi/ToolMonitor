using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess.CQRS.Queries
{

    public class GetCompaniesQuery : QueryBase<List<Company>>
    {
        public override async Task<List<Company>> Execute(ToolStorageContext context)
        {
            return await context.Companies.ToListAsync();
        }
    }
}
