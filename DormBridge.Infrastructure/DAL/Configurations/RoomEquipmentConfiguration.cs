using DormBridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormBridge.Infrastructure.DAL.Configurations
{
    internal sealed class RoomEquipmentConfiguration : IEntityTypeConfiguration<RoomEquipment>
    {
        public void Configure(EntityTypeBuilder<RoomEquipment> builder)
        {
            builder.HasKey(re => re.Id);
           
            builder.Property(re => re.Refrigerator).IsRequired();

            builder.Property(re => re.Microwave).IsRequired();

            builder.Property(re => re.InternetAccess).IsRequired();

            builder.Property(re => re.AirConditioning).IsRequired();

            builder.Property(re => re.Heating).IsRequired();

            builder.Property(re => re.Bathroom).IsRequired();

            builder.HasOne(r =?)

            builder.Property(r => r.CreateDate).HasDefaultValueSql("(getdate())").HasColumnType("datetime").IsRequired();

            builder.Property(r => r.UpdateDate).HasDefaultValueSql("(getdate())").HasColumnType("datetime");
        }
    }
}
