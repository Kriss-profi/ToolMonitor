using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolMonitor.ApplicationServices.API.Domain.Categories
{
    public class AddCategoryRequest : RequestBase<AddCategoryResponse>
    {
        //public int CompanyId { get; set; }
        public string CategoryName { get; set; }
    }
}
