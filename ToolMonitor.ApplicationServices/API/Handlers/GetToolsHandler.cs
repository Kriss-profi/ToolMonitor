using AutoMapper;
using MediatR;
using ToolMonitor.ApplicationServices.API.Domain;
using ToolMonitor.DataAccess;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.ApplicationServices.API.Handlers
{
    public class GetToolsHandler : IRequestHandler<GetToolsRequest, GetToolsResponse>
    {
        private readonly IRepository<Tool> toolRepository;
        private readonly IMapper mapper;

        public GetToolsHandler(IRepository<DataAccess.Entities.Tool> toolRepository, IMapper mapper)
        {
            this.toolRepository = toolRepository;
            this.mapper = mapper;
        }

        public Task<GetToolsResponse> Handle(GetToolsRequest request, CancellationToken cancellationToken)
        {
            var tools = this.toolRepository.GetAll();
            var mappedTools = this.mapper.Map<List<Domain.Models.Tool>>(tools);

            var toolsResponse = new GetToolsResponse()
            {
                Data = mappedTools
            };

            return Task.FromResult(toolsResponse);

            //var tools = this.toolRepository.GetAll();
            //var domainTools = tools.Select(x => new Domain.Models.Tool()
            //{
            //    Id = x.Id,
            //    ToolName = x.ToolName,
            //    Description = x.ToolDescription,
            //});
            //// Czym jest wynik domainTools 
            //// Że trzeba go przenosić do listy
            //var response = new GetToolsResponse()
            //{
            //    Data = domainTools.ToList(),
            //};
            //return Task.FromResult(response);
        }
    }
}
