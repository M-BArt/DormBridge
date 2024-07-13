namespace DormBridge.Domain.Entities
{
    public sealed class RoomEquipment
    {
        public int Id { get; set; }
        public int RoomId { get; set; }

        public bool Refrigerator { get; set; }
        public bool Microwave { get; set; }
        public bool InternetAccess { get; set; }
        public bool AirConditioning { get; set; }
        public bool Heating { get; set; }
        public bool Bathroom { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public Room Room { get; set; } = null!;

        private RoomEquipment() { }

        public RoomEquipment(int id, int roomId, bool refrigerator, bool microwave, bool internetAccess, bool airConditioning, bool heating, bool bathroom, DateTime createDate, DateTime updateDate, Room room)
        {
            Id = id;
            RoomId = roomId;
            Refrigerator = refrigerator;
            Microwave = microwave;
            InternetAccess = internetAccess;
            AirConditioning = airConditioning;
            Heating = heating;
            Bathroom = bathroom;
            CreateDate = createDate;
            UpdateDate = updateDate;
            Room = room;
        }
    }
}
