using DormBridge.Domain.ValueObjects;

namespace DormBridge.Domain.Entities
{
    public sealed class Dormitory
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = null!;
        public string NumberOfFloors { get; set; } = null!;
        public string NumberOfRooms { get; set; } = null!;
        public Address Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Region { get; set; } = null!;
        public PostalCode PostalCode { get; set; } = null!;
        public string Country { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public ICollection<Room> Rooms { get; set; } = new List<Room>();
        public List<Personnel> Personnels { get; set; } = new List<Personnel>();

        private Dormitory() { }
    }
}
