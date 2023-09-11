using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.ApplicationServices.API.Domain;
using ToolMonitor.ApplicationServices.API.Domain.Categories;
using ToolMonitor.ApplicationServices.API.ErrorHandling;
using ToolMonitor.DataAccess;
using ToolMonitor.DataAccess.CQRS;
using ToolMonitor.DataAccess.CQRS.Queries;

namespace ToolMonitor.ApplicationServices.API.Handlers
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdRequest, GetCategoryByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExequtor;
        private readonly AccessCompany accessCompany;

        public GetCategoryByIdHandler(IMapper mapper, IQueryExecutor queryExequtor, AccessCompany accessCompany)
        {
            this.mapper = mapper;
            this.queryExequtor = queryExequtor;
            this.accessCompany = accessCompany;
        }
        public async Task<GetCategoryByIdResponse> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCategoryQuery(this.accessCompany)
            {
                Id = request.Id,
            };

            var category = await this.queryExequtor.Execute(query);

            if(category == null)
            {
                return new GetCategoryByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedCategory = this.mapper.Map<Domain.Models.Category>(category);
            var response = new GetCategoryByIdResponse()
            {
                Data = mappedCategory,
            };
            return response;
        }
    }
}
