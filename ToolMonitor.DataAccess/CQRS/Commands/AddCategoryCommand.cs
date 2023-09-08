using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess.CQRS.Commands
{
    public class AddCategoryCommand : CommandBase<Category, Category>
    {
        public override async Task<Category> Execute(ToolStorageContext context)
        {
            await context.Categories.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
