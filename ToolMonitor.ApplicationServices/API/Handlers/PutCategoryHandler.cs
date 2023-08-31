using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.ApplicationServices.API.Domain.Categories;
using ToolMonitor.DataAccess.CQRS;
using ToolMonitor.DataAccess.CQRS.Commands;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.ApplicationServices.API.Handlers
{
    public class PutCategoryHandler : IRequestHandler<PutCategoryRequest, PutCategoryResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public PutCategoryHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }
        public async Task<PutCategoryResponse> Handle(PutCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = this.mapper.Map<Category>(request);
            var command = new PutCategoryCommand() { Parameter = category };
            var categoryFromDb = await commandExecutor.Execute(command);
            var response = new PutCategoryResponse()
            {
                Data = this.mapper.Map<Domain.Models.Category>(categoryFromDb),
            };
            return response;
        }
    }
}
