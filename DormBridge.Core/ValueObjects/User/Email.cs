using System.Text.RegularExpressions;
using DormBridge.Domain.Exceptions;

namespace DormBridge.Domain.ValueObjects.User
{
    public sealed record Email
    {
        private static readonly Regex _regex = new(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.Compiled);

        public string Value { get; set; }

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new InvalidEmailException(value);

            if (!_regex.IsMatch(value)) throw new InvalidEmailException(value);

            Value = value;
        }

        public static implicit operator string(Email email) => email.Value;
        public static implicit operator Email(string value) => new(value);
        public override string ToString() => Value;
    }

}
