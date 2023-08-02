using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess.CQRS.Queries
{
    public class GetCategoriesQuery : QueryBase<List<Category>>
    {
        public int CompanyId { get; set; }
        public override async Task<List<Category>> Execute(ToolStorageContext context)
        {
            var category = await context.Categories.Where(x => x.CompanyId == this.CompanyId).ToListAsync();
            return category;
        }
    }
}
