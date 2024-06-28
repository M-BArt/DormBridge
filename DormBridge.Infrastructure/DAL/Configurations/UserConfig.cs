using DormBridge.Domain.Entities;
using DormBridge.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormBridge.Infrastructure.DAL.Configurations
{
    internal sealed class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
 
            // Definiowanie klucza głównego
            builder.HasKey(u => u.UserGuid);

            // Konfiguracja właściwości
            builder.Property(u => u.Username)
                .HasMaxLength(256);



            builder.OwnsOne(u => u.Email, email =>
            {
                email.Property(e => e.Value).HasColumnName("Email").HasMaxLength(256);
            });

            builder.Property(u => u.CreateDate)
                .HasColumnType("datetime");

            builder.Property(u => u.UpdateDate)
                .HasColumnType("datetime");

            // Unikalny indeks dla Username
            builder.HasIndex(u => u.Username).IsUnique();
        }
    }
}



