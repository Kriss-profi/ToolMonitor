using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolMonitor.ApplicationServices.API.Domain.Dealers
{
    public class DeleteDealerRequest : IRequest<DeleteDealerResponse>
    {
        public int Id { get; set; }
    }
}
