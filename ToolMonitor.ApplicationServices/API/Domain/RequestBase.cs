using MediatR;

namespace ToolMonitor.ApplicationServices.API.Domain
{
    public class RequestBase<T> : IRequest<T>
    {
    }
}
