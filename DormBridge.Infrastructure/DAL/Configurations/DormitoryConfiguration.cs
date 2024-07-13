using DormBridge.Domain.Entities;
using DormBridge.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormBridge.Infrastructure.DAL.Configurations
{
    internal sealed class DormitoryConfiguration : IEntityTypeConfiguration<Dormitory>
    {
        public void Configure(EntityTypeBuilder<Dormitory> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(u => u.Name).IsRequired().HasMaxLength(30);
            builder.HasIndex(u => u.Name).IsUnique();

            builder.Property(u => u.NumberOfFloors).IsRequired();

            builder.Property(u => u.NumberOfRooms).IsRequired();

            builder.Property(d => d.Address).IsRequired().HasConversion(d => d.Value, d => new Address(d)); ;

            builder.Property(u => u.City).IsRequired();

            builder.Property(u => u.Region).IsRequired();

            builder.Property(u => u.PostalCode).IsRequired().HasConversion(p => p.Value, p => new PostalCode(p)).HasMaxLength(6);

            builder.Property(u => u.Country).IsRequired();

            builder.HasMany(r => r.Rooms).WithOne(d => d.Dormitory).HasForeignKey(d => d.DormitoryId);
            
            builder.Property(u => u.CreateDate).HasDefaultValueSql("(getdate())").HasColumnType("datetime").IsRequired();
            
            builder.Property(u => u.UpdateDate).HasDefaultValueSql("(getdate())").HasColumnType("datetime").IsRequired();
        }

    }
}
