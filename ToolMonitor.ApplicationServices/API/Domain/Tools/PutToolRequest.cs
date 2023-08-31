using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolMonitor.ApplicationServices.API.Domain.Tools
{
    public class PutToolRequest : IRequest<PutToolResponse>
    {
        public int Id { get; set; }
        public string ToolName { get; set; }
        public string ToolDescription { get; set; }
        public int? ManufacturerId { get; set; }
        public int? DealerId { get; set; }
        public int? InvoiceId { get; set; }
        public int? CategoryId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime BayData { get; set; }
        public int Varanty { get; set; }
    }
}
