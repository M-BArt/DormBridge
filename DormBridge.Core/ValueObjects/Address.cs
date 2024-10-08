﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormBridge.Domain.ValueObjects
{
    public sealed record Address
    {
        public string Value { get; set; }
        public Address(string value)
        {
            Value = value;
        }

        public static implicit operator Address(string value) => new(value);
        public static implicit operator string(Address address) => address.Value;
        public override string ToString() => Value;
    }
}
