using DormBridge.Application.Abstractions;

namespace DormBridge.Application.Commands.User
{
    public record ChangePassword(string currentPassword, string newPassword) : ICommand;
}
