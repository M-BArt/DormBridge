namespace DormBridge.Domain.Entities
{
    public class Room
    {
        public Guid RoomGuid { get; set; }

        public int Capacity { get; set; }
        public int Occupied { get; set; }

        public bool HasBathroom { get; set; }
        public bool HasKitchen { get; set; }
        public bool HasInternet { get; set; }
        public bool HasAirConditioning { get; set; }
        public bool IsAvailable { get; set; }

        public DateTime LastMaintenanceDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
