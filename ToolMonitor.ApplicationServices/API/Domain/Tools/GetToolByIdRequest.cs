using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolMonitor.ApplicationServices.API.Domain.Tools
{
    public class GetToolByIdRequest : RequestBase<GetToolByIdResponse>
    {
        public int ToolId { get; set; }
    }
}
