using Microsoft.EntityFrameworkCore;
using FARSOUND.Domain.Entities;
using FARSOUND.Application.Context;
using System.Reflection;

namespace FARSOUND.Infrastructure
{
    public class FARSOUNDDbContext : DbContext, IFARSOUNDDbContext
    {
        public FARSOUNDDbContext(DbContextOptions<FARSOUNDDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly()
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
