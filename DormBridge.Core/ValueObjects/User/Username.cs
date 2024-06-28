using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormBridge.Domain.ValueObjects.User
{
    public sealed record Username
    {
        public string Value { get; }

        public Username(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            Value = value;
        }

        public static implicit operator string(Username userName) => userName.Value;
        public static implicit operator Username(string value) => new(value);
    }
}
