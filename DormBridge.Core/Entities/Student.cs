using DormBridge.Domain.ValueObjects;
using DormBridge.Domain.ValueObjects.Student;

namespace DormBridge.Domain.Entities
{
    public sealed class Student
    {
        public Guid StudnetGuid { get; set; }
        public Guid? UserId { get; set; }   
        public int? RoomId { get; set; }

        public StudentAlbum StudentAlbum { get; set; } = null!;

        public Name Firstname { get; set; } = null!;
        public Name Lastname { get; set; } = null!;
        public Address Address { get; set; } = null!;
        public Phone? PhoneNumber { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        
        public User? User { get; set; }
        public Room? Room { get; set; }

        private Student() { }

        public Student(Guid studnetGuid, Guid? userId, int? roomId, StudentAlbum studentAlbum, Name firstname, Name lastname, Address address, Phone? phoneNumber, DateTime createDate, DateTime updateDate, User? user, Room? room)
        {
            StudnetGuid = studnetGuid;
            UserId = userId;
            RoomId = roomId;
            StudentAlbum = studentAlbum;
            Firstname = firstname;
            Lastname = lastname;
            Address = address;
            PhoneNumber = phoneNumber;
            CreateDate = createDate;
            UpdateDate = updateDate;
            User = user;
            Room = room;
        }
    }
}
