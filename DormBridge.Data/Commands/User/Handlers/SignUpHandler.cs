using System.Security.Cryptography;
using DormBridge.Application.Abstractions;
using DormBridge.Domain.Repositories;
using DormBridge.Domain.ValueObjects.User;

namespace DormBridge.Application.Commands.User.Handlers
{
    public class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly IUserRepository _userRepository;

        public SignUpHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task HandleAsyncAction(SignUp command)
        {
            if (await _userRepository.GetUserByEmailAsync(new Email(command.Email)) is not null)
                throw new Exception("Bad Email");
            if (await _userRepository.GetUserByNameAsync(new Username(command.Username)) is not null)
                throw new Exception("Bad Username");
            if (!(command.Password == command.RepeatPassword))
                throw new Exception("Bad Password");

            var role = Role.Student();
            var studentId = command.StudentId;

            CreateHashPassword(command.Password, out byte[] passwordHash, out byte[] passwordSalt);
            
            var user = new Domain.Entities.User(
                Guid.NewGuid(),
                new Username(command.Username),
                new Email(command.Email),
                role,
                studentId,
                passwordHash,
                passwordSalt,
                DateTime.Now,
                DateTime.Now
            );

            await _userRepository.AddAsync(user);

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
