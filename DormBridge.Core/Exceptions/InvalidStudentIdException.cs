using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormBridge.Domain.Exceptions
{
    public sealed class InvalidStudentIdException : Exception
    {
        public string Value { get; set; }
        public InvalidStudentIdException(string value) : base($"Student ID: {value} is invalid.")
        { 
            Value = value;
        }
    }
}
