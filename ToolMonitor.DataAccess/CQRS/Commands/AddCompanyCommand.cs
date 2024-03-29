﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess.CQRS.Commands
{
    public class AddCompanyCommand : CommandBase<Company, Company>
    {
        public override async Task<Company> Execute(ToolStorageContext context)
        {
            await context.Companies.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
