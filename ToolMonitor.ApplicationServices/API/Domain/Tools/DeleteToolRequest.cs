using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolMonitor.ApplicationServices.API.Domain.Tools
{
    public class DeleteToolRequest : RequestBase<DeleteToolResponse>
    {
        public int Id { get; set; }
    }
}
