using DormBridge.Application.Abstractions;
using Entities = DormBridge.Domain.Entities;

namespace DormBridge.Application.Commands.Room.Handlers
{
    public class CreateRoomHandler : ICommandHandler<CreateRoom>
    {
        public CreateRoomHandler()
        {

        }
        public Task HandleAsyncAction(CreateRoom command)
        {
            
            
            var room = Entities.Room.Create(123, command.roomArea, command.roomType, command.roomNumber, command.capacity, 0, false, DateTime.Now, DateTime.Now, DateTime.Now);
        }
    }
}
