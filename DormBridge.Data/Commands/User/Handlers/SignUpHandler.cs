using System.Security.Cryptography;
using DormBridge.Application.Abstractions;
using DormBridge.Application.Exceptions.User;
using DormBridge.Domain.Repositories;
using DormBridge.Domain.ValueObjects.User;
using DormBridge.Domain.ValueObjects.Student;

namespace DormBridge.Application.Commands.User.Handlers
{
    public class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly IUserRepository _userRepository;
        private readonly IStudentRepository _studentRepository;

        public SignUpHandler(IUserRepository userRepository, IStudentRepository studentRepository)
        {
            _userRepository = userRepository;
            _studentRepository = studentRepository;
        }

        public async Task HandleAsyncAction(SignUp command)
        {
            if (await _userRepository.GetUserByEmailAsync(new Email(command.Email)) is not null)
                throw new EmailAlreadyInUseException(command.Email);         
            if (await _userRepository.GetUserByNameAsync(new Username(command.Username)) is not null)
                throw new UsernameAlreadyInUseException(command.Username);
            if (await _userRepository.GetUserByStudentIdAsync(new StudentId(command.StudentId)) is not null)
                throw new StudentIdAlreadyInUse(command.StudentId);
            if (!(command.Password == command.RepeatPassword))
                throw new Exception("Passwords aren't the same");

            var studentId = command.StudentId;
            CreateHashPassword(command.Password, out byte[] passwordHash, out byte[] passwordSalt);
            
            var role = Role.User();
            if (await _studentRepository.GetStudentByStudentIdAsync(new StudentId(command.StudentId)) is not null)
                Role.Student();

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
