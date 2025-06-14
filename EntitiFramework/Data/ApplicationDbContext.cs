using EntitiFramework.Model;
using Microsoft.EntityFrameworkCore;


namespace EntitiFramework.Data
{
    public class ApplicationDbContext : DbContext
    {
       // public DbSet<Users> Users { get; set; }
        public DbSet<Products> Products { get; set; }
        public ApplicationDbContext()
        {           
            //Database.EnsureCreated();
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ROMAN;Database=Store; Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
