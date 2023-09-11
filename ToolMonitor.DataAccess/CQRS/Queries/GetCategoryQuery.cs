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
        public GetCategoryQuery(AccessCompany accessCompany)
        {
            AccessCompany = accessCompany;
        }
        public int Id { get; set; }
        public int CompanyId { get; set; } // = Claims.CompanyId jak to dodać 
        public AccessCompany AccessCompany { get; }

        public override async Task<Category> Execute(ToolStorageContext context)
        {
            CompanyId = AccessCompany.CompanyId;
            return await context.Categories.FirstOrDefaultAsync(x => x.Id == Id && x.CompanyId == CompanyId);
        }
    }
}
