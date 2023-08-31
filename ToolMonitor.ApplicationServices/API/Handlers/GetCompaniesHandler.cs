using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.ApplicationServices.API.Domain.Companies;
using ToolMonitor.DataAccess.CQRS;
using ToolMonitor.DataAccess.CQRS.Queries;

namespace ToolMonitor.ApplicationServices.API.Handlers
{
    public class GetCompaniesHandler : IRequestHandler<GetCompanyRequest, GetCompanyResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor executor;

        public GetCompaniesHandler(IMapper mapper, IQueryExecutor executor)
        {
            this.mapper = mapper;
            this.executor = executor;
        }
        public async Task<GetCompanyResponse> Handle(GetCompanyRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCompaniesQuery();
            var companies = await this.executor.Execute(query);
            var mappedCompanies = this.mapper.Map<List<Domain.Models.Company>>(companies);
            var response = new GetCompanyResponse()
            {
                Data = mappedCompanies,
            };
            return response;
        }
    }
}
