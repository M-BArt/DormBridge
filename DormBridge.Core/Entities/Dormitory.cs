namespace DormBridge.Domain.Entities
{
    public sealed class Dormitory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NumberOfFloors { get; set; }
        public string NumberOfRooms { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public ICollection<Room> Rooms { get; set; } = new List<Room>();
        public List<Personnel> Personnels { get; set; } = new List<Personnel>();

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public Dormitory(int id, string name, string numberOfFloors, string numberOfRooms, string address, string city, string region, string postalCode, string country, DateTime createDate, DateTime updateDate)
        {
            Id = id;
            Name = name;
            NumberOfFloors = numberOfFloors;
            NumberOfRooms = numberOfRooms;
            Address = address;
            City = city;
            Region = region;
            PostalCode = postalCode;
            Country = country;
            CreateDate = createDate;
            UpdateDate = updateDate;
        }
    }
}
