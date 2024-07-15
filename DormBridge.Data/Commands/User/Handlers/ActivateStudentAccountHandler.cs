using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DormBridge.Application.Abstractions;
using DormBridge.Application.Authenticator;
using DormBridge.Application.Exceptions.User;
using DormBridge.Domain.Repositories;
using DormBridge.Domain.ValueObjects.Student;
using DormBridge.Domain.ValueObjects.User;
using Microsoft.AspNetCore.Http;

namespace DormBridge.Application.Commands.User.Handlers
{
    public class ActivateStudentAccountHandler : ICommandHandler<ActivateStudentAccount>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticator _authenticator;
        public ActivateStudentAccountHandler(IStudentRepository studentRepository, IUserRepository userRepository, IAuthenticator authenticator)
        {
            _studentRepository = studentRepository;
            _userRepository = userRepository;
            _authenticator = authenticator;
        }


        public async Task HandleAsyncAction(ActivateStudentAccount command)
        {
            var userId = _authenticator.TakeTokenFromSession().Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var user = await _userRepository.GetUserById(Guid.Parse(userId));

            if (user.Role == Role.Student()) throw new AccountAlreadyHasStudentStatus();

            var student = await _studentRepository.GetStudentByStudentAlbumAsync(new StudentAlbum(command.studentAlbum)) ?? throw new StudentIdNoExist(command.studentAlbum);

            if (student.UserId == null) throw new StudentIdAlreadyInUse(command.studentAlbum);

            
            user.Role = Role.Student();

            student.UserId = user.UserGuid;
            
            
            await _studentRepository.UpdateAsync(student);
            
            await _userRepository.UpdateAsync(user);
        }
    }
}
 