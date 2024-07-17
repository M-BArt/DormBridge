using DormBridge.Application.Abstractions;

namespace DormBridge.Application.Commands.Student
{
    public record DeleteStudent(Guid studentId) : ICommand;
}
