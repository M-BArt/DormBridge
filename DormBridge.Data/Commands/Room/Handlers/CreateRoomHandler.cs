using DormBridge.Application.Abstractions;
using DormBridge.Domain.Repositories;
using Entities = DormBridge.Domain.Entities;

namespace DormBridge.Application.Commands.Room.Handlers
{
    public class CreateRoomHandler : ICommandHandler<CreateRoom>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IDormitoryRepository _dormitoryRepository;

        public CreateRoomHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task HandleAsyncAction(CreateRoom command)
        {
            if (await _dormitoryRepository.GetById(command.dormitoryId) == null)
                throw new Exception("Dormitory not exist");

            var room = Entities.Room.Create(command.dormitoryId, command.roomArea, command.roomType, command.roomNumber, command.capacity, 0, false, DateTime.Now, DateTime.Now, DateTime.Now);

            await _roomRepository.AddRoom(room);
        }
    }
}
