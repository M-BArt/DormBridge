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

        public StudentIdNoExist(string value) :base ($"Student id [{value}] no exist. Use a valid student ID to register an account, or leave the field blank.")
        {
            Value = value;
        }
    }
}
