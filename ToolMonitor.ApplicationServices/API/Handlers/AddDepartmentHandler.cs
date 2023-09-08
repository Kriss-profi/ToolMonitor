using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.ApplicationServices.API.Domain.Departments;
using ToolMonitor.ApplicationServices.API.Domain.Models;
using ToolMonitor.DataAccess.CQRS;
using ToolMonitor.DataAccess.CQRS.Commands;

namespace ToolMonitor.ApplicationServices.API.Handlers
{
    public class AddDepartmentHandler : IRequestHandler<AddDepartmentRequest, AddDepartmentResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddDepartmentHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }
        public async Task<AddDepartmentResponse> Handle(AddDepartmentRequest request, CancellationToken cancellationToken)
        {
            var department = this.mapper.Map<DataAccess.Entities.Department>(request);
            var command = new AddDepartmentCommand() { Parameter = department };
            var departmentFromDb = await commandExecutor.Execute(command);
            return new AddDepartmentResponse() { Data = this.mapper.Map<Department>(departmentFromDb) };
        }
    }
}
