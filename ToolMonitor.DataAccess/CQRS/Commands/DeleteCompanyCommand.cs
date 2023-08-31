using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess.CQRS.Commands
{
    public class DeleteCompanyCommand : CommandBase<Company, Company>
    {
        public int Id { get; set; }
        private int UserId { get; set; }
        public override async Task<Company> Execute(ToolStorageContext context)
        {
            var company = await context.Companies.FirstOrDefaultAsync(x => x.Id == this.Id);
            //var user = await context.Users.FirstOrDefaultAsync(x => x.CompanyId == this.Id);
            if (company != null)
            {
                var users = await context.Users.Where(x => x.CompanyId == this.Id).ToListAsync();
                var categories = await context.Categories.Where(x => x.CompanyId == this.Id).ToListAsync();
                var dealers = await context.Dealers.Where(x => x.CompanyId == this.Id).ToListAsync();
                var departments = await context.Departments.Where(x => x.CompanyId == this.Id).ToListAsync();
                var employees = await context.Employees.Where(x => x.CompanyId == this.Id).ToListAsync();
                var manufacturers = await context.Manufacturers.Where(x => x.CompanyId == this.Id).ToListAsync();
                var tools = await context.Tools.Where(x => x.CompanyId == this.Id).ToListAsync();


                foreach (var user in users) 
                { 
                    user.CompanyId = null;
                    context.Users.Update(user); 
                }

                foreach(var category in categories) { context.Categories.Remove(category); }

                foreach(var dealer in dealers) { context.Dealers.Remove(dealer); }

                foreach(var department in departments) { context.Departments.Remove(department); }

                foreach(var employee in employees) { context.Employees.Remove(employee); }

                foreach(var manufacturer in manufacturers) { context.Manufacturers.Remove(manufacturer); }

                foreach(var tool in tools) { context.Tools.Remove(tool); }

                context.Companies.Remove(company);
            }
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
