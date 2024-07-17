using DormBridge.Application.Abstractions;
using DormBridge.Application.Commands.Room;
using Microsoft.AspNetCore.Mvc;

namespace DormBridge.API.Controllers
{
    [ApiController]
    public partial class RoomController : BaseController<RoomController>
    {
        private readonly ICommandHandler<CreateRoom> _createRoomHandler;

        public RoomController(ICommandHandler<CreateRoom> createRoomHandler)
        {
            _createRoomHandler = createRoomHandler;
        }
    }
}
