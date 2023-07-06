using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.CQRS.Queries;

namespace ToolMonitor.DataAccess.CQRS
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly ToolStorageContext context;
        public QueryExecutor(ToolStorageContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(context);
        }
    }
}
