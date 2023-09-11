using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolMonitor.ApplicationServices.API.Domain.Companies
{
    public class AddCompanyRequest : RequestBase<AddCompanyResponse>
    {
        public string CompanyName { get; set; }
        public string CompanyCity { get; set; }
    }
}
