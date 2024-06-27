using System.ComponentModel.DataAnnotations;
using DormBridge.Domain.ValueObjects;

namespace DormBridge.Domain.Entities
{
    public sealed class User
    {
        [Key]
        public Guid UserGuid { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Email Email { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public User() { } // Bezparametrowy konstruktor

        public User(string username, byte[] passwordHash, byte[] passwordSalt, Email email)
        {
            Username = username;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Email = email;
        }

    }
}
