using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.ApplicationServices.API.Domain.Categories;
using ToolMonitor.DataAccess.CQRS;
using ToolMonitor.DataAccess.CQRS.Queries;

namespace ToolMonitor.ApplicationServices.API.Handlers
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdRequest, GetCategoryByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExequtor;

        public GetCategoryByIdHandler(IMapper mapper, IQueryExecutor queryExequtor)
        {
            this.mapper = mapper;
            this.queryExequtor = queryExequtor;
        }
        public async Task<GetCategoryByIdResponse> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCategoryQuery()
            {
                Id = request.Id,
            };

            var category = await this.queryExequtor.Execute(query);
            var mappedCategory = this.mapper.Map<Domain.Models.Category>(category);
            var response = new GetCategoryByIdResponse()
            {
                Data = mappedCategory,
            };
            return response;
        }
    }
}
