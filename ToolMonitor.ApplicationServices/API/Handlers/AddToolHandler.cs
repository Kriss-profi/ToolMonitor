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
using ToolMonitor.DataAccess.CQRS.Commands;

namespace ToolMonitor.ApplicationServices.API.Handlers
{
    public class AddToolHandler : IRequestHandler<AddToolRequest, AddToolResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddToolHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }
        public async Task<AddToolResponse> Handle(AddToolRequest request, CancellationToken cancellationToken)
        {
            var tool = mapper.Map<DataAccess.Entities.Tool>(request);
            var command = new AddToolCommand() { Parameter = tool };
            var toolFromDb = await this.commandExecutor.Execute(command);
            return new AddToolResponse()
            {
                Data = this.mapper.Map<Tool>(toolFromDb)
            };
        }
    }
}
