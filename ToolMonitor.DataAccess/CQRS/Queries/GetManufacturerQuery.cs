using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess.CQRS.Queries
{
    public class GetManufacturerQuery : QueryBase<Manufacturer>
    {
        public int Id { get; set; }
        public override async Task<Manufacturer> Execute(ToolStorageContext context)
        {
            return await context.Manufacturers.FirstOrDefaultAsync(x => x.Id == this.Id);
        }
    }
}
