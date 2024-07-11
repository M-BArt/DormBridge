using DormBridge.Domain.ValueObjects.Student;
using DormBridge.Domain.ValueObjects.User;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DormBridge.Domain.Entities
{
    public sealed class User
    {
        public Guid UserGuid { get; set; }
        public Username Username { get; set; }
        public Email Email { get; set; }
        public Role Role { get; set; }
        public StudentId? StudentId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public User(Guid userGuid, Username username, Email email, Role role, StudentId studentId, byte[] passwordHash, byte[] passwordSalt, DateTime createDate, DateTime updateDate)
        {
            UserGuid = userGuid;
            Username = username;
            Email = email;
            Role = role;
            StudentId = studentId;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            CreateDate = createDate;
            UpdateDate = updateDate;

        }

        public void ChangePassword(byte[] newPasswordHash, byte[] newPasswordSalt)
        {
            if (newPasswordHash == null)
                throw new Exception("xxx");

            PasswordHash = newPasswordHash;
            PasswordSalt = newPasswordSalt;
        }
    }
}
