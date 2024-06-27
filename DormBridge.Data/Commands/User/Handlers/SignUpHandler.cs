using System.Security.Cryptography;
using DormBridge.Application.Abstractions;
using DormBridge.Domain.Repositories;
using DormBridge.Domain.ValueObjects;
using DormBridge.Domain.Entities;

namespace DormBridge.Application.Commands.User.Handlers
{
    public class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly IUserRepository _userRepository;
        public async Task HandleAsyncAction(SignUp command)
        {
            var Username = command.Username;
            var Password = command.Password;
            var RepeatPassword = command.RepeatPassword;
            var Email = new Email(command.Email);
            //var StudentId = command.StudentId;


            if (await _userRepository.GetUserByEmailAsync(Email) is not null)
                throw new Exception("asdasd");
            if (await _userRepository.GetUserByNameAsync(Username) is not null)
                throw new Exception("asdassdasd");
            if (!(Password == RepeatPassword))
                throw new Exception("asdasdasdasd");

            CreateHashPassword(Password, out byte[] PasswordHash, out byte[] PasswordSalt);

            var user = new Domain.Entities.User(Username, PasswordHash, PasswordSalt, Email);

            _userRepository.AddAsync(user);
        }

        private static (byte[], byte[]) CreateHashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (HMACSHA256 hmac = new())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            return (passwordHash, passwordSalt);

        }
    }
}
