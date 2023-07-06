using MediatR;
using System.Linq;
using ToolMonitor.ApplicationServices.API.Domain;
using ToolMonitor.DataAccess.CQRS;
using ToolMonitor.DataAccess.CQRS.Queries;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.ApplicationServices.API.Handlers
{
    public class GetToolsCQRSHandler : IRequestHandler<GetToolsCQRSRequest, GetToolsCQRSResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        
        public GetToolsCQRSHandler(IQueryExecutor queryExecutor)
        {
            this.queryExecutor  = queryExecutor;
        }

        public  async Task<GetToolsCQRSResponse> Handle(GetToolsCQRSRequest request, CancellationToken cancellation)
        {
            var query = new GetToolsQuery();
            var tools = await queryExecutor.Execute(query);
            var mapedTools = tools.Select(x => new Domain.Models.Tool()
            {
                Id = x.Id,
                ToolName = x.ToolName,
                Description = x.ToolDescription,
            });
            // Czym jest wynik domainTools 
            // Że trzeba go przenosić do listy
            var response = new GetToolsCQRSResponse()
            {
                Data = mapedTools.ToList(),
            };
            return response;
        }
    }
}
