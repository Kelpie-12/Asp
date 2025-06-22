using API.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<UserData> Storege { get; set; }
        public DbSet<UserTask> Tasks { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTask>().Property(property => property.CreatedAt).HasDefaultValueSql("getdate");
            //modelBuilder.Entity<UserTask>().Property(property => property.IsDone).HasDefaultValue(0);
        }
    }
}
