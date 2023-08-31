using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolMonitor.ApplicationServices.API.Domain.Manufacturers
{
    public class PutManufacturerRequest : IRequest<PutManufacturerResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Web { get; set; }
    }
}
