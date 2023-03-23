using Microsoft.EntityFrameworkCore;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.DataAccess
{
    public class ToolStorageContext : DbContext
    {
        public ToolStorageContext(DbContextOptions<ToolStorageContext> opt) : base(opt)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
