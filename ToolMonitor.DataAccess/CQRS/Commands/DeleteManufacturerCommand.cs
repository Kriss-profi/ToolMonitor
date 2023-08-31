using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess.CQRS.Commands
{
    public class DeleteManufacturerCommand : CommandBase<Manufacturer, Manufacturer>
    {
        public int Id { get; set; }
        public override async Task<Manufacturer> Execute(ToolStorageContext context)
        {
            var manufacturer = await context.Manufacturers.FirstOrDefaultAsync(x => x.Id == this.Id);
            if(manufacturer != null)
            {
                context.Manufacturers.Remove(manufacturer);
            }
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
