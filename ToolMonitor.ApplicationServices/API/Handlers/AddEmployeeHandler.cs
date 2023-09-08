using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.ApplicationServices.API.Domain.Employees;
using ToolMonitor.ApplicationServices.API.Domain.Models;
using ToolMonitor.DataAccess.CQRS;
using ToolMonitor.DataAccess.CQRS.Commands;

namespace ToolMonitor.ApplicationServices.API.Handlers
{
    public class AddEmployeeHandler : IRequestHandler<AddEmployeeRequest, AddEmployeeResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddEmployeeHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }
        public async Task<AddEmployeeResponse> Handle(AddEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employee = this.mapper.Map<DataAccess.Entities.Employee>(request);
            var command = new AddEmployeeCommand() {  Parameter = employee };
            var employeeFromDb = await commandExecutor.Execute(command);
            return new AddEmployeeResponse() { Data = this.mapper.Map<Employee>(employeeFromDb) };
        }
    }
}
