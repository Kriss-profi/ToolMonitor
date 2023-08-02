using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess.CQRS.Queries
{
    public class GetCategoryQuery : QueryBase<Category>
    {
        public int Id { get; set; }

        public override async Task<Category> Execute(ToolStorageContext context)
        {
            return await context.Categories.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}
