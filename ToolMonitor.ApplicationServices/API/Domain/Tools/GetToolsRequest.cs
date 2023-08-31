using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolMonitor.ApplicationServices.API.Domain.Tools
{
    public class GetToolsRequest : IRequest<GetToolsResponse>
    {
        public string ToolName { get; set; }
        public GetToolsRequest()
        {
            ToolName = "";
        }

        public GetToolsRequest(string name)
        {
            ToolName = name;
        }
    }
}
