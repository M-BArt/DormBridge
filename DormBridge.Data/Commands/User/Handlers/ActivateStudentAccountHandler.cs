using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DormBridge.Application.Abstractions;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string token;
        public ActivateStudentAccountHandler(IStudentRepository studentRepository, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _studentRepository = studentRepository;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task HandleAsyncAction(ActivateStudentAccount command)
        {
            var authHeader = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();

            if (authHeader != null && authHeader.StartsWith("Bearer"))
            {
                token = authHeader.Substring("Bearer ".Length).Trim();
            }
            else
            {
                token = _httpContextAccessor.HttpContext?.Session.GetString("JWToken") ?? string.Empty;
            }

            JwtSecurityTokenHandler tokenHandler = new();
            JwtSecurityToken decryptedToken = tokenHandler.ReadJwtToken(token);

            var userId = decryptedToken.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var user = await _userRepository.GetUserById(Guid.Parse(userId));

            var student = await _studentRepository.GetStudentByStudentAlbumAsync(new StudentAlbum(command.studentAlbum)) ?? throw new StudentIdNoExist(command.studentAlbum);

            user.Role = Role.Student();

            student.UserId = user.UserGuid;
        }
    }
}
