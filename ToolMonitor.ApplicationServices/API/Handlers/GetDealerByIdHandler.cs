using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.ApplicationServices.API.Domain.Dealers;
using ToolMonitor.DataAccess.CQRS;
using ToolMonitor.DataAccess.CQRS.Queries;

namespace ToolMonitor.ApplicationServices.API.Handlers
{
    public class GetDealerByIdHandler : IRequestHandler<GetDealerByIdRequest, GetDealerByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetDealerByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetDealerByIdResponse> Handle(GetDealerByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetDealerQuery()
            {
                Id = request.Id,
            };

            var dealer = await queryExecutor.Execute(query);
            var mapperDealer = mapper.Map<Domain.Models.Dealer>(dealer);
            var dealerResponse = new GetDealerByIdResponse()
            {
                Data = mapperDealer,
            };
            return dealerResponse;
        }
    }
}
