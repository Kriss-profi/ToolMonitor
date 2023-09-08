using AutoMapper;
using MediatR;
using ToolMonitor.ApplicationServices.API.Domain.Dealers;
using ToolMonitor.ApplicationServices.API.Domain.Models;
using ToolMonitor.DataAccess.CQRS;
using ToolMonitor.DataAccess.CQRS.Commands;

namespace ToolMonitor.ApplicationServices.API.Handlers
{
    public class AddDealerHandler : IRequestHandler<AddDealerRequest, AddDealerResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddDealerHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }
        public async Task<AddDealerResponse> Handle(AddDealerRequest request, CancellationToken cancellationToken)
        {
            var dealer = this.mapper.Map<DataAccess.Entities.Dealer>(request);
            var command = new AddDealerCommand() { Parameter = dealer };
            var dealerFromDb = await commandExecutor.Execute(command);
            return new AddDealerResponse()
            {
                Data = this.mapper.Map<Dealer>(dealerFromDb)
            };
        }
    }
}
