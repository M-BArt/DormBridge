using DormBridge.Domain.Entities;
using DormBridge.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace DormBridge.Domain.ValueObjects.User
{
    public sealed record Role
    {
        private const string user = "user";
        private const string student = "student";
        private const string personnel = "personnel";

        private IEnumerable<string> Roles { get; } = [user, student, personnel]; 
        
        public string Value { get; set; }

        public Role(string value)
        {
            if (!Roles.Contains(value))
                throw new ArgumentException();
                
                Value = value;
        }

        public static Role User() => new(user);
        public static Role Student() => new(student);
        public static Role Personnel() => new(personnel);


        public static implicit operator string(Role role) => role.Value;
        public static implicit operator Role(string value) => new(value);
        public override string ToString() => Value;
    }
}
