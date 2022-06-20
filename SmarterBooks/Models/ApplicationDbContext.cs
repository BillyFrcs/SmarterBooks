using Microsoft.EntityFrameworkCore;

namespace SmarterBooks.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Books>? Books => Set<Books>();

        // public DbSet<Book>? Books { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}