using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolMonitor.ApplicationServices.API.Domain.Manufacturers
{
    public class GetManufacturerByIdRequest : RequestBase<GetManufacturerByIdResponse>
    {
        public int ManufacturerId { get; set; }
    }
}
