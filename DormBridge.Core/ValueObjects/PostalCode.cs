using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DormBridge.Domain.ValueObjects
{
    public sealed record PostalCode
    {
        private static readonly Regex _regex = new(@"^\d{2}-\d{3}$", RegexOptions.Compiled);
        public string Value;
        public PostalCode(string value) 
        {
            if (!_regex.IsMatch(value)) throw new Exception("Bad Postal Code");
            
            Value = value;
        }

        public static implicit operator PostalCode(string value) => new(value);
        public static implicit operator string(PostalCode postalCode) => postalCode.Value;
        public override string ToString() => Value;

    }
}
