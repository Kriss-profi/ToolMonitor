using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToolMonitor.ApplicationServices.API.Domain;

namespace ToolMonitor.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        private readonly IMediator mediator;

        public ApiControllerBase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest<TResponse>
            where TResponse : ErrorResponseBase
        {
            var response = await this.mediator.Send(request);
            if(response.Error != null)
            {
                //return this.ErrorResponse(response.Error);
            }

            return this.Ok(response);
        }
    }
}
