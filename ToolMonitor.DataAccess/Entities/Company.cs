using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolMonitor.DataAccess.Entities
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string CompanyName { get; set; }
        [MaxLength(50)]
        public string CompanyCity { get; set; }

    }
}
