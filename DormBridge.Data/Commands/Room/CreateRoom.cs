using DormBridge.Application.Abstractions;

namespace DormBridge.Application.Commands.Room
{
    public record CreateRoom(int dormitoryId, float roomArea, string roomType, int roomNumber, int capacity, bool refrigerator, bool microwave, bool internetAccess, bool heating, bool bathroom) : ICommand;

}
