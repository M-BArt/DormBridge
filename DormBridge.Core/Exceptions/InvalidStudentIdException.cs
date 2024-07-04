using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormBridge.Application.Exceptions;

namespace DormBridge.Domain.Exceptions
{
    public sealed class InvalidStudentIdException : BusinessException
    {
        public string Value { get; set; }
        public InvalidStudentIdException(string value) : base($"Student ID: [{value}] is invalid. The proper format of a student ID is 9 digits.")
        { 
            Value = value;
        }
    }
}
