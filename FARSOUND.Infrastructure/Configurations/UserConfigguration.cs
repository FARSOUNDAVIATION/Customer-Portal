using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FARSOUND.Domain.Entities;


namespace FARSOUND.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "Register");

            builder.Property(s => s.UserName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(s => s.Email)
                .HasMaxLength(1000);

            builder.Property(s => s.Password)
                .HasMaxLength(1000);

            builder.Property(s => s.SecurityAnswer)
                .HasMaxLength(1000);

            builder.Property(s => s.SecurityQuestion)
                .HasMaxLength(1000);
        }
    }
}
