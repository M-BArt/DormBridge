using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormBridge.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DormBridge.Infrastructure.DAL.Configurations
{
    internal sealed class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(u => u.StudnetGuid);

            builder.Property(u => u.StudentId).IsRequired().HasMaxLength(9);
            builder.HasIndex(u => u.StudentId).IsUnique();

            builder.Property(u => u.Firstname).IsRequired();
            builder.Property(u => u.Lastname).IsRequired();
            builder.Property(u => u.Address);
            builder.Property(u => u.PhoneNumber);

            //builder.Property(u => u.Email).IsRequired().HasMaxLength(100)
            //    .HasConversion(u => u.Value, u => new Email(u));
            //builder.HasIndex(u => u.Email).IsUnique();
          
            builder.Property(u => u.CreateDate).HasColumnType("datetime").IsRequired();
            builder.Property(u => u.UpdateDate).HasColumnType("datetime").IsRequired();
        }
    }
}



