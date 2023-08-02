using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.CQRS.Commands;

namespace ToolMonitor.DataAccess.CQRS
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly ToolStorageContext context; 

        public CommandExecutor(ToolStorageContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
        {
            return command.Execute(this.context);         
        }
    }
}
