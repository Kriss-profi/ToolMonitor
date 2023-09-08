using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess.CQRS.Commands
{
    public class AddDealerCommand : CommandBase<Dealer, Dealer>
    {
        public override async Task<Dealer> Execute(ToolStorageContext context)
        {
            context.Dealers.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
