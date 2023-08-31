using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.ApplicationServices.API.Domain.Manufacturers;
using ToolMonitor.ApplicationServices.API.Domain.Models;
using ToolMonitor.DataAccess.CQRS;
using ToolMonitor.DataAccess.CQRS.Queries;

namespace ToolMonitor.ApplicationServices.API.Handlers
{
    public class GetManufacturersHandler : IRequestHandler<GetManufacturersRequest, GetManufacturersResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetManufacturersHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetManufacturersResponse> Handle(GetManufacturersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetManufacturersQuery();
            var manufacturers = await queryExecutor.Execute(query);
            var mappedManufacturers = mapper.Map<List<Manufacturer>>(manufacturers);
            var response = new GetManufacturersResponse()
            {
                Data = mappedManufacturers,
            };
            return response;
        }
    }
}
