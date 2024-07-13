using DormBridge.Domain.ValueObjects.User;

namespace DormBridge.Domain.Entities
{
    public sealed class User
    {
        public Guid UserGuid { get; set; }
        
        public Username Username { get; set; } = null!;
        public Email Email { get; set; } = null!;
        public Role Role { get; set; } = null!;
       
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
       
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        
        public Student? Student { get; set; }
        public Personnel? Personnel { get; set; }
        
        private User() { }

        public User(Guid userGuid, Username username, Email email, Role role, byte[] passwordHash, byte[] passwordSalt, DateTime createDate, DateTime updateDate, Student? student, Personnel? personnel)
        {
            UserGuid = userGuid;
            Username = username;
            Email = email;
            Role = role;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            CreateDate = createDate;
            UpdateDate = updateDate;
            Student = student;
            Personnel = personnel;
        }

        public void ChangePassword(byte[] newPasswordHash, byte[] newPasswordSalt)
        {
            PasswordHash = newPasswordHash;
            PasswordSalt = newPasswordSalt;
        }
    }
}