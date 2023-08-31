using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolMonitor.ApplicationServices.API.Domain.Departments
{
    public class PutDepartmentRequest : IRequest<PutDepartmentResponse>
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
    }
}
