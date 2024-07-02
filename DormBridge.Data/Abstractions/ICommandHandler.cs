namespace DormBridge.Application.Abstractions
{
    public interface ICommandHandler<TCommand> where TCommand : class, ICommand
    {
        Task HandleAsyncAction(TCommand command);
    }

}
