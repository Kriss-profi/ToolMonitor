using AutoMapper;
using MediatR;
using ToolMonitor.ApplicationServices.API.Domain.Categories;
using ToolMonitor.DataAccess;
using ToolMonitor.DataAccess.CQRS;
using ToolMonitor.DataAccess.CQRS.Queries;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.ApplicationServices.API.Handlers
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoryRequest, GetCategoryResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetCategoriesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetCategoryResponse> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
        {
            int company = 1;

            var query = new GetCategoriesQuery();

            query.CompanyId = company;
            
            
            var categories = await this.queryExecutor.Execute(query);
            var mappedCategories = this.mapper.Map<List<Domain.Models.Category>>(categories);

            var categoriesResponse = new GetCategoryResponse()
            {
                Data = mappedCategories
            };

            return categoriesResponse;
        }
    }
}
