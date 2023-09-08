using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.ApplicationServices.API.Domain.Companies;
using ToolMonitor.ApplicationServices.API.Domain.Models;
using ToolMonitor.DataAccess.CQRS;
using ToolMonitor.DataAccess.CQRS.Commands;

namespace ToolMonitor.ApplicationServices.API.Handlers
{
    public class AddCompanyHandler : IRequestHandler<AddCompanyRequest, AddCompanyResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddCompanyHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }
        public async Task<AddCompanyResponse> Handle(AddCompanyRequest request, CancellationToken cancellationToken)
        {
            var company = mapper.Map<DataAccess.Entities.Company>(request);
            var command = new AddCompanyCommand() { Parameter = company };
            var companyFromDb = await this.commandExecutor.Execute(command);
            return new AddCompanyResponse()
            {
                Data = mapper.Map<Company>(companyFromDb),
            };
        }
    }
}
