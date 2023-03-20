using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolMonitor.DataAccess.Entities
{
    public class Tool : EntitieBase
    {
        //public int Id { get; set; }
        public string ToolName { get; set; }
        public string ToolDescription { get; set; }
        public DateTime BayData { get; set; }
        public int Varanty { get; set; }

    }
}
