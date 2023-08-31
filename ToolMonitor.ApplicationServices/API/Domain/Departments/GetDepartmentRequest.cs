using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolMonitor.ApplicationServices.API.Domain.Departments
{
    public class GetDepartmentRequest : IRequest<GetDepartmentResponse>
    {
        //public int CompanyId { get; set; } = 1;
    }
}
