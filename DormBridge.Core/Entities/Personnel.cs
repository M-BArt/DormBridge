using DormBridge.Domain.ValueObjects;
using DormBridge.Domain.ValueObjects.Student;

namespace DormBridge.Domain.Entities
{
    public class Personnel
    {
        public Guid PresonnelId { get; set; }
        public Guid UserId { get; set; }
        public int DormitoryId { get; set; } 

        public Name Firstname { get; set; } = null!;
        public Name Lastname { get; set; } = null!;
        public Address Address { get; set; } = null!;
        public Phone PhoneNumber { get; set; } = null!;

        public User User { get; set; } = null!;
        public Dormitory Dormitory { get; set; } = null!;

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
