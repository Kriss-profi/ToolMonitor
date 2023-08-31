using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess.CQRS.Queries
{
    public class GetAllUsersQuery : QueryBase<List<User>>
    {
        public override Task<List<User>> Execute(ToolStorageContext context)
        {
            return context.Users.ToListAsync();
        }
    }
}
