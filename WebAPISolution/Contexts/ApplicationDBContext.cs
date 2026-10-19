using Microsoft.EntityFrameworkCore;
using WebAPISolution.Models;

namespace WebAPISolution.Contexts
{
    public class ApplicationDBContext : DbContext
    {

        public DbSet<Student> Student { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        protected ApplicationDBContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
