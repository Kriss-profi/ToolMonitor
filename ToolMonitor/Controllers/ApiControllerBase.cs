using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using ToolMonitor.ApplicationServices.API.Domain;
using ToolMonitor.ApplicationServices.API.ErrorHandling;
using ToolMonitor.DataAccess;

namespace ToolMonitor.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        private readonly IMediator mediator;
        private AccessCompany accessCompany;

        public ApiControllerBase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public ApiControllerBase(IMediator mediator, AccessCompany accessCompany) : this(mediator)
        {
            this.accessCompany = accessCompany;
        }

        protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
            where TRequest : RequestBase<TResponse>
            where TResponse : ErrorResponseBase
        {
            if(!this.ModelState.IsValid)
            {
                return this.BadRequest(
                    this.ModelState
                    .Where(x => x.Value.Errors.Any())
                    .Select(x => new { property = x.Key, errors = x.Value.Errors }));
            }

            //var userCompanyId = accessCompany.CompanyId;

            var response = await this.mediator.Send(request);
            if(response.Error != null)
            {
                return this.ErrorResponse(response.Error);
            }

            return this.Ok(response);
        }

        private IActionResult ErrorResponse(ErrorModel errorModel)
        {
            var httpCode = GetHttpStatusCode(errorModel.Error);
            return StatusCode((int)httpCode, errorModel);
        }

        private static HttpStatusCode GetHttpStatusCode(string errorType)
        {
            switch (errorType)
            {
                case ErrorType.NotFound: return HttpStatusCode.NotFound;
                case ErrorType.InternalServerError: return HttpStatusCode.InternalServerError;
                case ErrorType.Unauthorized: return HttpStatusCode.Unauthorized;
                case ErrorType.RequestTooLarge: return HttpStatusCode.BadRequest;
                case ErrorType.UnsupportedMediaType: return HttpStatusCode.UnsupportedMediaType;
                case ErrorType.UnsupportedMethod: return HttpStatusCode.MethodNotAllowed;
                case ErrorType.TooManyRequests: return (HttpStatusCode)429;
                default:
                    return HttpStatusCode.BadRequest;
            }
        }
    }
}
