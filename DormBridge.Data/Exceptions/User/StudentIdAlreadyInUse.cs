using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormBridge.Application.Exceptions.User
{
    public sealed class StudentIdAlreadyInUse : Exception
    {
        public string StudentId { get; set; }
        public StudentIdAlreadyInUse(string studentId) : base($"Student ID: {studentId} is already in use")
        {
            StudentId = studentId;
        }
    }
}
