
using Blog.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.data.Sqlite
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext()
        {

        }

        public CustomerDbContext(DbContextOptions options) : base(options)
        {

        }
        // 
        public DbSet<Customer> Customers { get; set; }
    }
}