using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace ToolMonitor.DataAccess
{
    public class ToolStorageContextFactory : IDesignTimeDbContextFactory<ToolStorageContext>
    {
        public ToolStorageContext CreateDbContext(string[] args)
        {
            
            var optionsBuilder = new DbContextOptionsBuilder<ToolStorageContext>();
            optionsBuilder.UseSqlServer("Data Source=kriss\\sqlexpress;Initial Catalog=ToolMonitorCStorage;Integrated Security=True");
            return new ToolStorageContext(optionsBuilder.Options);
        }
    }
}
