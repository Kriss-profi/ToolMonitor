using AutoMapper;
using MediatR;
using ToolMonitor.ApplicationServices.API.Domain;
using ToolMonitor.ApplicationServices.API.Domain.Tools;
using ToolMonitor.DataAccess;
using ToolMonitor.DataAccess.CQRS;
using ToolMonitor.DataAccess.CQRS.Queries;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.ApplicationServices.API.Handlers
{
    public class GetToolByIdHandler : IRequestHandler<GetToolByIdRequest, GetToolByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetToolByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetToolByIdResponse> Handle(GetToolByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetToolQuery()
            {
                Id = request.ToolId,
            };
            var tool = await this.queryExecutor.Execute(query);
            var mappedTool = this.mapper.Map<Domain.Models.Tool>(tool);

            var toolResponse = new GetToolByIdResponse()
            {
                Data = mappedTool
            };

            return toolResponse;

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
