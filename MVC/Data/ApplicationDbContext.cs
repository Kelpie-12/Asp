using Microsoft.EntityFrameworkCore;
using MVC.Data.Models;

namespace MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            // Database.EnsureCreated();      
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .Property(product => product.CreatedAt)
                .HasDefaultValueSql("getdate()");
            builder.Entity<Review>()
                .Property(product => product.CreatedAt)
                .HasDefaultValueSql("getdate()");
            builder.Entity<User>()
                .Property(product => product.CreatedAt)
                .HasDefaultValueSql("getdate()");
        }
    }
}
