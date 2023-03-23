using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolMonitor.DataAccess.Entities
{
    public class Tool : EntityBase
    {
        [Required]
        [MaxLength(250)]
        public string ToolName { get; set; }
        [MaxLength(500)]
        public string ToolDescription { get; set; }
        public int ManufactureeId { get; set; }
        public int DealerId { get; set; }
        public int InvoiceId { get; set; }
        public int CategoryId { get; set; }
        public DateTime BayData { get; set; }
        public int Varanty { get; set; }

    }
}
