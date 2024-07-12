using DormBridge.Domain.Entities;
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

            builder.Property(u => u.Address).IsRequired();

            builder.Property(u => u.City).IsRequired();

            builder.Property(u => u.Region).IsRequired();

            builder.Property(u => u.PostalCode).IsRequired();

            builder.Property(u => u.Country).IsRequired();

            builder.HasMany(r => r.Rooms).WithOne(d => d.Dormitory).HasForeignKey(d => d.DormitorygId);
            
            builder.Property(u => u.CreateDate).HasDefaultValueSql("(getdate())").HasColumnType("datetime").IsRequired();
            
            builder.Property(u => u.UpdateDate).HasDefaultValueSql("(getdate())").HasColumnType("datetime").IsRequired();
        }

    }
}
