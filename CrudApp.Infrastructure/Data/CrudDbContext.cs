using CrudApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace CrudApp.Infrastructure.Data
{
    public class CrudDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public CrudDbContext(DbContextOptions<CrudDbContext> options) : base(options) { }
    }
}
