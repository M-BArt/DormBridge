using DormBridge.Domain.ValueObjects.Room;

namespace DormBridge.Domain.Entities
{
    public sealed class Room
    {
        public int Id { get; set; }
        public float RoomArea { get; set; }
        public RoomType RoomType { get; set; } = null!;
        public int RoomNumber { get; set; }
        public int Capacity { get; set; }
        public int Occupied { get; set; }
        public bool IsAvailable { get; set; }
       
        
        
        
        
        public List<User> Users { get; set; } = new List<User>();
        
        
        
        
        
        public int DormitorygId { get; set; }
        public Dormitory Dormitory { get; set; } = null!;
             
        public int RoomEquipmentId { get; set; }
        public RoomEquipment RoomEquipment { get; set; }
         
        
        public DateTime LastMaintenanceDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
