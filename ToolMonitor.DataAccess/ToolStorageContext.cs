using Microsoft.EntityFrameworkCore;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess
{
    public class ToolStorageContext : DbContext
    {
        public ToolStorageContext(DbContextOptions<ToolStorageContext> opt) : base(opt)
        {
        }

        public DbSet<Tool> Tools { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
