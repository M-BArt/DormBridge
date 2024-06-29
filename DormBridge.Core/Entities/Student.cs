using DormBridge.Domain.ValueObjects.Student;

namespace DormBridge.Domain.Entities
{
    public sealed class Student
    {

        public Guid StudnetGuid { get; set; }
        public StudentId StudentId { get; set; }
        public Name Firstname { get; set; }
        public Name Lastname { get; set; }
        public Address Address { get; set; }
        public Phone PhoneNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public Student(Guid studnetGuid, StudentId studentId, Name firstname, Name lastname, Address address, Phone phoneNumber, DateTime createDate, DateTime updateDate)
        {
            StudnetGuid = studnetGuid;
            StudentId = studentId;
            Firstname = firstname;
            Lastname = lastname;
            Address = address;
            PhoneNumber = phoneNumber;
            CreateDate = createDate;
            UpdateDate = updateDate;
        }
    }
}
