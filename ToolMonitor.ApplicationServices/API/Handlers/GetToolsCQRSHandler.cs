using MediatR;
using System.Linq;
using ToolMonitor.ApplicationServices.API.Domain.Tools;
using ToolMonitor.DataAccess.CQRS;
using ToolMonitor.DataAccess.CQRS.Queries;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.ApplicationServices.API.Handlers
{
    public class GetToolsCQRSHandler : IRequestHandler<GetToolsRequest, GetToolsResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        
        public GetToolsCQRSHandler(IQueryExecutor queryExecutor)
        {
            this.queryExecutor  = queryExecutor;
        }

        public  async Task<GetToolsResponse> Handle(GetToolsRequest request, CancellationToken cancellation)
        {
            var query = new GetToolsQuery();
            var tools = await queryExecutor.Execute(query);
            var mapedTools = tools.Select(x => new Domain.Models.Tool()
            {
                Id = x.Id,
                ToolName = x.ToolName,
                ToolDescription = x.ToolDescription,
            });
            // Czym jest wynik domainTools 
            // Że trzeba go przenosić do listy
            var response = new GetToolsResponse()
            {
                Data = mapedTools.ToList(),
            };
            return response;
        }
    }
}
