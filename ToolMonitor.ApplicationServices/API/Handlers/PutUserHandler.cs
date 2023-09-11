using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.ApplicationServices.API.Domain.Users;
using ToolMonitor.DataAccess.CQRS;
using ToolMonitor.DataAccess.CQRS.Commands;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.ApplicationServices.API.Handlers
{
    public class PutUserHandler : IRequestHandler<PutUserRequest, PutUserResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public PutUserHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }
        public async Task<PutUserResponse> Handle(PutUserRequest request, CancellationToken cancellationToken)
        {
            var user = this.mapper.Map<User>(request);
            var command = new PutUserCommand() { Parameter = user };
            var userFromDb = await commandExecutor.Execute(command);
            var response = new PutUserResponse()
            {
                Data = this.mapper.Map<Domain.Models.User>(userFromDb),
            };
            return response;
        }
    }
}
