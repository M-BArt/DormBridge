using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormBridge.Domain.ValueObjects.Room
{
    public sealed record RoomType
    {
        private const string singleRoom = "Single room";
        private const string doubleRoom = "Double room";
        private const string dormitory = "Dormitory";

        private IEnumerable<string> RoomTypes { get; } = [singleRoom, doubleRoom, dormitory];

        public string Value { get; set; }

        public RoomType(string value)
        {
            if (!RoomTypes.Contains(value)) throw new ArgumentException();

            Value = value;
        }

        public static RoomType SingleRoom() => new(singleRoom);
        public static RoomType DoubleRoom() => new(doubleRoom);
        public static RoomType Dormitory() => new(dormitory);

        public static implicit operator string(RoomType roomtype) => roomtype.Value;
        public static implicit operator RoomType(string value) => new(value);
        public override string ToString() => Value;
    }
}
