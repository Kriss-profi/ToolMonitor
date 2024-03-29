﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess.CQRS.Queries
{
    public class  GetUserQuery : QueryBase<User>
    {
        //public int? CompanyId { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public string Email { get; set; }
        public override async Task<User> Execute(ToolStorageContext context)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Email == this.Email);
        }
    }
}
