using AutoMapper;
using MediatR;
using ToolMonitor.ApplicationServices.API.Domain.Dealers;
using ToolMonitor.ApplicationServices.API.Domain.Models;
using ToolMonitor.DataAccess.CQRS;
using ToolMonitor.DataAccess.CQRS.Queries;

namespace ToolMonitor.ApplicationServices.API.Handlers
{
    public class GetDealersHandler : IRequestHandler<GetDealersRequest, GetDealersResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetDealersHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetDealersResponse> Handle(GetDealersRequest request, CancellationToken cancellationToken)
        {
            int company = 1;
            var query = new GetDealersQuery();
            query.CompanyId = company;
            var dealers = await this.queryExecutor.Execute(query);
            var mappedDealers = this.mapper.Map<List<Dealer>>(dealers);
            var dealersResponse = new GetDealersResponse()
            {
                Data = mappedDealers,
            };
            return dealersResponse;
        }
    }
}
