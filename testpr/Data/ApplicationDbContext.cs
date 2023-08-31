using Microsoft.EntityFrameworkCore;
using System.Data;
using testpr.Models;

namespace testpr.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Category> categories { get; set; } 
        public DbSet<CoverType> coverTypes { get; set; }
        public DbSet<Product> products { get; set; }
    }
}
