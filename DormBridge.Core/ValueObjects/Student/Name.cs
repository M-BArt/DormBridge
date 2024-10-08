﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace DormBridge.Domain.ValueObjects.Student
{
    public sealed class Name
    {
        public string Value { get; set; }
        public Name(string value)
        {
            if (value.IsNullOrEmpty())
                throw new ArgumentNullException("value"); 

            Value = value;
        }

        public static implicit operator Name(string value) => new(value);
        public static implicit operator string(Name value) => value.Value;
        public override string ToString() => Value;
    }
}
