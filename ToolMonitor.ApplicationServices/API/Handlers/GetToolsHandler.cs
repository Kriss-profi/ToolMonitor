using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.ApplicationServices.API.Domain.Models;
using ToolMonitor.ApplicationServices.API.Domain.Tools;
using ToolMonitor.DataAccess.CQRS;
using ToolMonitor.DataAccess.CQRS.Queries;

namespace ToolMonitor.ApplicationServices.API.Handlers
{
    public class GetToolsHandler : IRequestHandler<GetToolsRequest, GetToolsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetToolsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetToolsResponse> Handle(GetToolsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetToolsQuery();
            if(request.ToolName != null)
            {
                query.ToolName = request.ToolName;
            }
            var tools = await this.queryExecutor.Execute(query);
            var mappedTools = this.mapper.Map<List<Tool>>(tools);
            var response = new GetToolsResponse()
            {
                Data = mappedTools,
            };
            return response;
        }
    }
}
