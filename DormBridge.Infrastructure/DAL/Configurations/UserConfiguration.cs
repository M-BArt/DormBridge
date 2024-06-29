using DormBridge.Domain.Entities;
using DormBridge.Domain.ValueObjects;
using DormBridge.Domain.ValueObjects.Student;
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

            builder.Property(u => u.Username).IsRequired().HasMaxLength(30)
                .HasConversion(u => u.Value, u => new Username(u));

            builder.HasIndex(u => u.Username).IsUnique();

            builder.Property(u => u.Email).IsRequired().HasMaxLength(100)
                .HasConversion(u => u.Value, u => new Email(u));
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.Role).IsRequired()
                .HasConversion(u => u.Value, u => new Role(u));

            builder.Property(u => u.StudentId)
                .HasConversion(u => u.Value, u => new StudentId(u));

            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.PasswordSalt).IsRequired();
            builder.Property(u => u.CreateDate).HasColumnType("datetime").IsRequired();
            builder.Property(u => u.UpdateDate).HasColumnType("datetime").IsRequired();
        }
    }
}



