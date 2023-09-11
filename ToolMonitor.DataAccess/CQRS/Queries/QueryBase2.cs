using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolMonitor.DataAccess.CQRS.Queries
{
    public abstract class QueryBase2<TResult>
    {
        public abstract Task<TResult> Execute(ToolStorageContext context, AccessCompany accessCompany);
    }
}
