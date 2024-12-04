using Microsoft.EntityFrameworkCore;
using FARSOUND.Domain.Entities;
using System.Reflection;

namespace FARSOUND.Infrastructure
{
    public class FARSOUNDDbContext : DbContext
    {
        public FARSOUNDDbContext(DbContextOptions<FARSOUNDDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly()
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
