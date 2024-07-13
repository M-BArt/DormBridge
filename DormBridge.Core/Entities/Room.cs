using DormBridge.Domain.ValueObjects.Room;

namespace DormBridge.Domain.Entities
{
    public sealed class Room
    {
        public int Id { get; set; }
        public int DormitoryId { get; set; }

        public float RoomArea { get; set; }
        public RoomType RoomType { get; set; } = null!;
        public int RoomNumber { get; set; }
        public int Capacity { get; set; }
        public int Occupied { get; set; }
        public bool IsAvailable { get; set; }        
        
        public DateTime LastMaintenanceDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public List<Student> Studnets { get; set; } = new List<Student>();
        public Dormitory Dormitory { get; set; } = null!;
        public RoomEquipment RoomEquipment { get; set; } = null!;

        private Room() { }

    }
}
