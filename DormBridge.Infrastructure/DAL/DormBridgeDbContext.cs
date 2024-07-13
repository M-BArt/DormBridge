using DormBridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DormBridge.Infrastructure.DAL
{
    internal sealed class DormBridgeDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Dormitory> Dormitories { get; set; }
        public DbSet<RoomEquipment> RoomEquipments { get; set; }
        public DbSet<Personnel> Personnels { get; set; }

        public DormBridgeDbContext(DbContextOptions<DormBridgeDbContext> dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

    }
}
