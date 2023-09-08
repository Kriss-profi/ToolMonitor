using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolMonitor.ApplicationServices.API.Domain
{
    public class ErrorModel
    {
        public ErrorModel(string error)
        {
            Error = error;
        }

        public string Error { get; }
    }
}
