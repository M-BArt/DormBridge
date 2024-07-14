using DormBridge.Application.Abstractions;

namespace DormBridge.Application.Commands.User
{
    public record ActivateStudentAccount(string studentAlbum) : ICommand;
}
