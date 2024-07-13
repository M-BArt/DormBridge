using DormBridge.Application.Abstractions;
using DormBridge.Application.Exceptions.User;
using DormBridge.Domain.Entities;
using DormBridge.Domain.Repositories;
using DormBridge.Domain.ValueObjects.Student;
using DormBridge.Domain.ValueObjects.User;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.IdentityModel.Tokens;

namespace DormBridge.Application.Commands.User.Handlers
{
    public class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly IUserRepository _userRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IPasswordManager _passwordManager;
        public SignUpHandler(IUserRepository userRepository, IStudentRepository studentRepository, IPasswordManager passwordManager)
        {
            _userRepository = userRepository;
            _studentRepository = studentRepository;
            _passwordManager = passwordManager;
        }

        public async Task HandleAsyncAction(SignUp command)
        {                     
            if (await _userRepository.GetUserByEmailAsync(new Email(command.Email)) != null) throw new EmailAlreadyInUseException(command.Email);
            if (await _userRepository.GetUserByNameAsync(new Username(command.Username)) != null) throw new UsernameAlreadyInUseException(command.Username);
            if (await _userRepository.GetUserByStudentIdAsync(new StudentAlbum(command.StudentAlbum)) != null) throw new StudentIdAlreadyInUse(command.StudentAlbum);
            if (!(command.Password == command.RepeatPassword)) throw new PasswordsAreNotTheSame();

            var userId = Guid.NewGuid();
            
            _passwordManager.CreateHashPassword(new Password(command.Password), out byte[] passwordHash, out byte[] passwordSalt);         
            
            var user = new Domain.Entities.User(
                userId,
                new Username(command.Username),
                new Email(command.Email),
                null,
                passwordHash,
                passwordSalt,
                DateTime.Now,
                DateTime.Now,
                null,
                null
            );

            user.Role = Role.User();

            if (!command.StudentAlbum.IsNullOrEmpty())
            {
                var student = await _studentRepository.GetStudentByStudentAlbumAsync(new StudentAlbum(command.StudentAlbum));
                if (student != null)
                {
                    user.Role = Role.Student();
                    student.UserId = user.UserGuid;
                    student.UpdateDate = DateTime.UtcNow;
                    await _studentRepository.UpdateAsync(student);
                }
                else
                {
                    throw new StudentIdNoExist(command.StudentAlbum);
                }
            }

       
            await _userRepository.AddAsync(user);
        }
    }
}
