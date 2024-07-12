using DormBridge.Domain.ValueObjects.Student;

namespace DormBridge.Domain.Entities
{
    public class Personnel
    {
        public Guid Guid { get; set; }
        public Name Firstname { get; set; }
        public Name Lastname { get; set; }
        public Address Address { get; set; }
        public Phone PhoneNumber { get; set; }
        
        public int DormitoryId { get; set; }
        public Dormitory Dormitory { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
