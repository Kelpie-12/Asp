using Microsoft.EntityFrameworkCore;
using MVC.Data.Models;

namespace MVC.Data
{
    public class ApplicationDbContext:DbContext
    {       
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            Database.EnsureCreated();      
        }
    }
}
