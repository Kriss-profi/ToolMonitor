using AutoMapper;
using MediatR;
using System.Security.Claims;
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
        private readonly AccessCompany accessCompany;

        public GetCategoriesHandler(IMapper mapper, IQueryExecutor queryExecutor, AccessCompany accessCompany)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.accessCompany = accessCompany;
        }

        public async Task<GetCategoryResponse> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
        {
            int company = accessCompany.CompanyId;

            var query = new GetCategoriesQuery(this.accessCompany);

            query.CompanyId = accessCompany.CompanyId;
            
            
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
