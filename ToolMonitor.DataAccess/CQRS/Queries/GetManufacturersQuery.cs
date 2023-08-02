using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess.CQRS.Queries
{
    public class GetManufacturersQuery : QueryBase<List<Manufacturer>>
    {
        public int CompanyId { get; set; }
        public override async Task<List<Manufacturer>> Execute(ToolStorageContext context)
        {
            return await context.Manufacturers.Where(x => x.CompanyId == this.CompanyId).ToListAsync();
        }
    }
}
