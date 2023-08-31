using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.ApplicationServices.API.Domain.Companies;
using ToolMonitor.DataAccess.CQRS;
using ToolMonitor.DataAccess.CQRS.Commands;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.ApplicationServices.API.Handlers
{
    public class PutCompanyHandler : IRequestHandler<PutCompanyRequest, PutCompanyResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public PutCompanyHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }
        public async Task<PutCompanyResponse> Handle(PutCompanyRequest request, CancellationToken cancellationToken)
        {
            var company = this.mapper.Map<Company>(request);
            var command = new PutCompanyCommand() { Parameter = company };
            var companyFromDb = await commandExecutor.Execute(command);
            var response = new PutCompanyResponse()
            {
                Data = this.mapper.Map<Domain.Models.Company>(companyFromDb),
            };
            return response;
        }
    }
}
