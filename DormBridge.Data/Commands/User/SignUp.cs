using DormBridge.Application.Abstractions;

namespace DormBridge.Application.Commands.User;
    public record SignUp(string Username, string Password, string RepeatPassword, string Email, int StudentId) : ICommand;

