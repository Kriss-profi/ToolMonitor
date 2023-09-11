using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolMonitor.ApplicationServices.API.Domain.Employees
{
    public class DeleteEmployeeRequest : RequestBase<DeleteEmployeeResponse>
    {
        public int Id { get; set; }
    }
}
