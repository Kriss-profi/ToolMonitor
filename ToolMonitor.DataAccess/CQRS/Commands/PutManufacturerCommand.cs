using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess.CQRS.Commands
{
    public class PutManufacturerCommand : CommandBase<Manufacturer, Manufacturer>
    {
        public override async Task<Manufacturer> Execute(ToolStorageContext context)
        {
            context.Manufacturers.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
