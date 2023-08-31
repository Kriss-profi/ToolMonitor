using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolMonitor.ApplicationServices.API.Domain.Companies
{
    public class DeleteCompanyRequest : IRequest<DeleteCompanyResponse>
    {
        public int CompanyId { get; set; }
    }
}
