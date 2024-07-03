using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormBridge.Application.Exceptions.User
{
    public sealed class StudentIdNoExist : BusinessException
    {
        public string Value { get; set; }

        public StudentIdNoExist(string value) :base ($"StudentID: Student id {value} no exist.")
        {
            Value = value;
        }
    }
}
