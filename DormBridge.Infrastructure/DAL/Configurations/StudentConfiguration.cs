using DormBridge.Domain.Entities;
using DormBridge.Domain.ValueObjects;
using DormBridge.Domain.ValueObjects.Student;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormBridge.Infrastructure.DAL.Configurations
{
    internal sealed class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(u => u.StudnetGuid);

            builder.Property(u => u.StudentAlbum).IsRequired().HasMaxLength(9).HasConversion(u => u.Value, u => new StudentAlbum(u));
            builder.HasIndex(u => u.StudentAlbum).IsUnique();

            builder.Property(u => u.Firstname).IsRequired().HasConversion(u => u.Value, u => new Name(u));

            builder.Property(u => u.Lastname).IsRequired().HasConversion(u => u.Value, u => new Name(u));

            builder.Property(u => u.Address).HasConversion(u => u.Value, u => new Address(u));

            builder.Property(u => u.PhoneNumber).HasConversion(u => u.Value, u => new Phone(u));

            builder.Property(u => u.CreateDate).HasDefaultValueSql("(getdate())").HasColumnType("datetime").IsRequired();

            builder.Property(u => u.UpdateDate).HasDefaultValueSql("(getdate())").HasColumnType("datetime").IsRequired();
        }
    }
}



