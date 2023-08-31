using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess.CQRS.Commands
{
    public class DeleteCategoryCommand : CommandBase<Category, Category>
    {
        public int Id  { get; set; }
        public override async Task<Category> Execute(ToolStorageContext context)
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == this.Id);
            if(category != null)
            {
                context.Categories.Remove(category);
            }
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
