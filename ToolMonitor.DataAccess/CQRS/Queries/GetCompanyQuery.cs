using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess.CQRS.Queries
{
    public class GetCompanyQuery : QueryBase<Company>
    {
        public int Id { get; set; }
        public override async Task<Company> Execute(ToolStorageContext context)
        {
            return await context.Companies.FirstOrDefaultAsync(x => x.Id == this.Id);
        }
    }
}
