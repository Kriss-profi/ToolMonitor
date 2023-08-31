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
    public class GetManufacturerByIdHandler : IRequestHandler<GetManufacturerByIdRequest, GetManufacturerByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetManufacturerByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetManufacturerByIdResponse> Handle(GetManufacturerByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetManufacturerQuery()
            {
                Id = request.ManufacturerId,
            };
            var manufacturer = await queryExecutor.Execute(query);
            var mappedManufacturer = mapper.Map<Manufacturer>(manufacturer);
            var response = new GetManufacturerByIdResponse()
            {
                Data = mappedManufacturer,
            };
            return response;
        }
    }
}
