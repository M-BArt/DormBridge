﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormBridge.Domain.Entities;
using DormBridge.Domain.ValueObjects.Room;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;

namespace DormBridge.Infrastructure.DAL.Configurations
{
    internal sealed class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.RoomArea);

            builder.Property(r => r.RoomType).IsRequired().HasConversion(r => r.Value, r => new RoomType(r));

            builder.Property(r => r.RoomNumber).IsRequired();
            
            builder.Property(r => r.Capacity).IsRequired();

            builder.Property(r => r.Occupied).IsRequired();

            builder.Property(r => r.IsAvailable).IsRequired();

            builder.Property(r => r.DormitorygId).IsRequired();

            builder.Property(r => r.RoomEquipmentId).IsRequired();

            builder.Property(r => r.LastMaintenanceDate).HasColumnType("datetime");

            builder.Property(r => r.CreateDate).HasDefaultValueSql("(getdate())").HasColumnType("datetime").IsRequired();

            builder.Property(r => r.UpdateDate).HasColumnType("datetime");
        }
    }
}
