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
    public class GetDepartmentByIdHandler : IRequestHandler<GetDepartmentByIdRequest, GetDepartmentByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetDepartmentByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetDepartmentByIdResponse> Handle(GetDepartmentByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetDepartmentQuery()
            {
                Id = request.DepartmentId,
            };
            var department = await queryExecutor.Execute(query);
            var mappedDepartment = mapper.Map<Department>(department);
            var response = new GetDepartmentByIdResponse()
            {
                Data = mappedDepartment,
            };
            return response;
        }
    }
}
