using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess.CQRS.Commands
{
    public class DeleteDealerCommand : CommandBase<Dealer, Dealer>
    {
        public int Id { get; set; }
        public override async Task<Dealer> Execute(ToolStorageContext context)
        {
            var dealer = await context.Dealers.FirstOrDefaultAsync(x => x.Id == this.Id);
            if(dealer != null)
            {
                context.Dealers.Remove(dealer);
            }
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
