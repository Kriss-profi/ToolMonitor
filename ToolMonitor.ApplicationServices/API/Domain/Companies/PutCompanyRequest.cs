using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolMonitor.ApplicationServices.API.Domain.Companies
{
    public class PutCompanyRequest : IRequest<PutCompanyResponse>
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } 
        public string CompanyCity { get; set; }
    }
}
