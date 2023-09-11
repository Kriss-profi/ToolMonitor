using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolMonitor.ApplicationServices.API.Domain.Dealers
{
    public class GetDealerByIdRequest : RequestBase<GetDealerByIdResponse>
    {
        public int Id { get; set; }
    }
}
