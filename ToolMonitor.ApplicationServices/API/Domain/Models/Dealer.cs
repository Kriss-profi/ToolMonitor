﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolMonitor.ApplicationServices.API.Domain.Models
{
    public class Dealer
    {
        public int Id { get; set; }
        public string DealerName { get; set; }
        public string DealerWeb { get; set; }
        public string DealerEmail { get; set; }
    }
}
