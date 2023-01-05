using Microsoft.EntityFrameworkCore;
using WebTest.Models;

namespace WebTest.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext( DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
