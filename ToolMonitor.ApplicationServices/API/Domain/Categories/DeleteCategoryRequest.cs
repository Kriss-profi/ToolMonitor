using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolMonitor.ApplicationServices.API.Domain.Categories
{
    public class DeleteCategoryRequest : RequestBase<DeleteCategoryResponse>
    {
        public int CategoryId { get; set; }
    }
}
