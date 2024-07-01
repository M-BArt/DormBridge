using DormBridge.Application.Abstractions;

namespace DormBridge.Application.Commands.User
{
    public record SignIn(string Login, string Password) : ICommand;
}
