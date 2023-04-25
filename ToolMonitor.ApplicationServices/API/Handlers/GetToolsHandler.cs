using MediatR;
using ToolMonitor.ApplicationServices.API.Domain;
using ToolMonitor.DataAccess;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.ApplicationServices.API.Handlers
{
    public class GetToolsHandler : IRequestHandler<GetToolsRequest, GetToolsResponse>
    {
        private readonly IRepository<Tool> toolRepository;

        public GetToolsHandler(IRepository<DataAccess.Entities.Tool> toolRepository)
        {
            this.toolRepository = toolRepository;
        }
        public Task<GetToolsResponse> Handle(GetToolsRequest request, CancellationToken cancellationToken)
        {
            var tools = this.toolRepository.GetAll();
            var domainTools = tools.Select(x => new Domain.Models.Tool()
            {
                Id = x.Id,
                Name = x.ToolName,
                Description = x.ToolDescription,
            });
            // Czym jest wynik domaintools 
            // Że trzeba go przenosić do listy
            var response = new GetToolsResponse()
            {
                Data = domainTools.ToList(),
            };
            return Task.FromResult(response);
        }
    }
}
