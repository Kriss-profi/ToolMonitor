using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolMonitor.DataAccess.Entities
{
    public class Manufacturer : EntityBase
    {
        public string Name { get; set; }
        public string Web { get; set; }
    }
}
