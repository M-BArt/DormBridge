using System.Text.RegularExpressions;
using DormBridge.Application.Exceptions;
using DormBridge.Domain.Exceptions;
using DormBridge.Domain.Repositories;
using Microsoft.AspNetCore.Identity;

namespace DormBridge.Domain.ValueObjects.User
{
    public sealed record Password
    {
        private readonly Regex _regex = new(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", RegexOptions.Compiled);

        private readonly string _password;

        public Password(string password)
        {
            if (!_regex.IsMatch(password)) throw new InvalidPasswordException();

            _password = password;
        }

        public static implicit operator string(Password password) => password._password;
        public static implicit operator Password(string value) => new(value);
        public override string ToString() => _password;
    }
}
