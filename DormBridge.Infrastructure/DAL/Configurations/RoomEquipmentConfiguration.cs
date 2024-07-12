using DormBridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormBridge.Infrastructure.DAL.Configurations
{
    internal sealed class RoomEquipmentConfiguration : IEntityTypeConfiguration<RoomEquipment>
    {
        public void Configure(EntityTypeBuilder<RoomEquipment> builder)
        {

        }
    }
}
