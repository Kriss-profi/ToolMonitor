using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess.CQRS.Queries
{
    public class GetDealerQuery : QueryBase<Dealer>
    {
        public int Id { get; set; }

        public override async Task<Dealer> Execute(ToolStorageContext context)
        {
            return await context.Dealers.FirstOrDefaultAsync(x => x.Id == this.Id);
        }
    }
}
