using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using FARSOUND.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace FARSOUND.Application.Context
{
    public interface IFARSOUNDDbContext
    {
        DbSet<User> Users { get; set; }

        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync
            (CancellationToken cancellationToken = default);

        EntityEntry Remove(object entity);

    }
}
