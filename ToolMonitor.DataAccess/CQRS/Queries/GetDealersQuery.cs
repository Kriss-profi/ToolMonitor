using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess.CQRS.Queries
{
    public class GetDealersQuery : QueryBase<List<Dealer>>
    {
        public int CompanyId { get; set; }
        public override async Task<List<Dealer>> Execute(ToolStorageContext context)
        {
            return await context.Dealers.Where(x => x.CompanyId == CompanyId).ToListAsync();
        }
    }
}
