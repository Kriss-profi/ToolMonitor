using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess.CQRS.Queries
{
    
    public class GetUsersQuery : QueryBase<List<User>>
    {
        public int CompanyId { get; set; }
        public override async Task<List<User>> Execute(ToolStorageContext context)
        {
            return await context.Users.Where(x => x.CompanyId == this.CompanyId).ToListAsync();
        }
    }
}
