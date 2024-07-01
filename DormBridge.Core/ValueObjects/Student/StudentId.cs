using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormBridge.Domain.Exceptions;
using DormBridge.Domain.ValueObjects.User;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;

namespace DormBridge.Domain.ValueObjects.Student
{
    public sealed record StudentId
    {
        public string? Value;

        public StudentId(string? value)
        {
            if (!value.IsNullOrEmpty())
            {
                if (value.Length != 9 || !value.All(char.IsDigit))
                    throw new InvalidStudentIdException(value);
            }
            else 
            { 
                value = null; 
            }

            Value = value;
        }

        public static implicit operator string?(StudentId studentId) => studentId.Value;
        public static implicit operator StudentId(string value) => new(value);
        public override string? ToString() => Value;
    }
}
