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

namespace ToolMonitor.ApplicationServices.API.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
        private readonly ICommandExecutor commandExecutor;

        public DeleteUserHandler(ICommandExecutor commandExecutor)
        {
            this.commandExecutor = commandExecutor;
        }
        public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var query = new DeleteUserCommand() { Id = request.Id };
            var response = await commandExecutor.Execute(query);
            return new DeleteUserResponse();
        }
    }
}
