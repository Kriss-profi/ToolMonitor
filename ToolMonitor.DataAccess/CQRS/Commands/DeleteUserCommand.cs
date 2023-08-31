using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess.CQRS.Commands
{
    public class DeleteUserCommand : CommandBase<User, User>
    {
        public int Id { get; set; }
        public override async Task<User> Execute(ToolStorageContext context)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == this.Id);
            if (user != null)
            {
                if (user.UserStatus != UserStatus.SuperAdmin)
                {
                    context.Users.Remove(user);
                }
                else
                {
                    // Message ???? You can't delete SuperAdmin !!!!
                }
            }
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
