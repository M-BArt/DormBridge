using DormBridge.Application.Abstractions;
using DormBridge.Application.DTOs.User;

namespace DormBridge.Application.Queries
{
    public class GetUsers : IQuery<IEnumerable<UserDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
