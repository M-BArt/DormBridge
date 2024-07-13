using DormBridge.Domain.Entities;
using DormBridge.Domain.ValueObjects.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormBridge.Infrastructure.DAL.Configurations
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserGuid);

            builder.Property(u => u.Username).IsRequired().HasMaxLength(30).HasConversion(u => u.Value, u => new Username(u));
            builder.HasIndex(u => u.Username).IsUnique();

            builder.Property(u => u.Email).IsRequired().HasMaxLength(100).HasConversion(u => u.Value, u => new Email(u));
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.Role).IsRequired().HasConversion(u => u.Value, u => new Role(u));

            builder.Property(u => u.PasswordHash).IsRequired();

            builder.Property(u => u.PasswordSalt).IsRequired();

            builder.Property(u => u.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(u => u.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .IsRequired();
            
            builder.HasOne(s => s.Student).WithOne(u => u.User).HasForeignKey<Student>(s => s.UserId);

            builder.HasOne(p => p.Personnel).WithOne(u => u.User).HasForeignKey<Personnel>(p => p.UserId);
        }
    }
}



