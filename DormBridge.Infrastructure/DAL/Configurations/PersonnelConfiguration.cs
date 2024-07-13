using DormBridge.Domain.Entities;
using DormBridge.Domain.ValueObjects;
using DormBridge.Domain.ValueObjects.Student;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormBridge.Infrastructure.DAL.Configurations
{
    internal sealed class PersonnelConfiguration : IEntityTypeConfiguration<Personnel>
    {
        public void Configure(EntityTypeBuilder<Personnel> builder)
        {
            builder.HasKey(p => p.PresonnelId);

            builder.Property(p => p.Firstname).IsRequired().HasConversion(p => p.Value, p => new Name(p));

            builder.Property(p => p.Lastname).IsRequired().HasConversion(p => p.Value, p => new Name(p));

            builder.Property(p => p.Address).IsRequired().HasConversion(p => p.Value, p => new Address(p));

            builder.Property(p => p.PhoneNumber).IsRequired().HasConversion(p => p.Value, p => new Phone(p)); ;

            builder.Property(p => p.CreateDate).HasDefaultValueSql("(getdate())").HasColumnType("datetime").IsRequired();

            builder.Property(p => p.UpdateDate).HasDefaultValueSql("(getdate())").HasColumnType("datetime");

            builder.HasOne(d => d.Dormitory).WithMany(d => d.Personnels).HasForeignKey(d => d.DormitoryId);
        }
    }
}
