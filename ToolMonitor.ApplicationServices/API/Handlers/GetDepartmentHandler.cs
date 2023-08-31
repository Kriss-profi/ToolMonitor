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
using ToolMonitor.DataAccess.CQRS.Queries;

namespace ToolMonitor.ApplicationServices.API.Handlers
{
    public class GetDepartmentHandler : IRequestHandler<GetDepartmentRequest, GetDepartmentResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetDepartmentHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetDepartmentResponse> Handle(GetDepartmentRequest request, CancellationToken cancellationToken)
        {
            var cleimCompanyId = 2;
            var query = new GetDepartmentsQuery()
            {
                //CompanyId = request.CompanyId,
                CompanyId = cleimCompanyId,
            };
            var departments = await this.queryExecutor.Execute(query);
            var mappedDepartments = this.mapper.Map<List<Department>>(departments);
            var response = new GetDepartmentResponse()
            {
                Data = mappedDepartments,
            };
            return response;
        }
    }
}
