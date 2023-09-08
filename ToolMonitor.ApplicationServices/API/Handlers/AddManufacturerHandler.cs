using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.ApplicationServices.API.Domain.Manufacturers;
using ToolMonitor.ApplicationServices.API.Domain.Models;
using ToolMonitor.DataAccess.CQRS;
using ToolMonitor.DataAccess.CQRS.Commands;

namespace ToolMonitor.ApplicationServices.API.Handlers
{
    public class AddManufacturerHandler : IRequestHandler<AddManufacturerRequest, AddManufacturerResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddManufacturerHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }
        public async Task<AddManufacturerResponse> Handle(AddManufacturerRequest request, CancellationToken cancellationToken)
        {
            var manufacturer = this.mapper.Map<DataAccess.Entities.Manufacturer>(request);
            var command = new AddManufacturerCommand() { Parameter = manufacturer };
            var manufacturerFromDb = await this.commandExecutor.Execute(command);
            return new AddManufacturerResponse()
            { 
                Data = this.mapper.Map<Manufacturer>(manufacturerFromDb)
            };
        }
    }
}
