using Microsoft.EntityFrameworkCore;
using ToolRentalSystem.Models;

namespace ToolRentalSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Tool> Tools { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}