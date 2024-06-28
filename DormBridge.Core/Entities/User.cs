using System.ComponentModel.DataAnnotations;
using DormBridge.Domain.ValueObjects.User;

namespace DormBridge.Domain.Entities
{
    public sealed class User
    {
        public Guid UserGuid { get; set; }
        public Username Username { get; set; }
        public Email Email { get; set; }
        public Role Role { get; set; }
        public string StudentId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public User() { }
        public User(Guid userGuid, Username username, Email email, Role role, string studentId, byte[] passwordHash, byte[] passwordSalt, DateTime createDate, DateTime updateDate)
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
    }
}
