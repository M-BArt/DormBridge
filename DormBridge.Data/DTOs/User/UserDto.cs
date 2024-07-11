using DormBridge.Domain.ValueObjects.Student;
using DormBridge.Domain.ValueObjects.User;

namespace DormBridge.Application.DTOs.User
{
    public class UserDto
    {
        public Guid UserGuid { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string StudentId { get; set; }
        public string Role {  get; set; } 
    }
}