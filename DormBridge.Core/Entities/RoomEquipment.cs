using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormBridge.Domain.Entities
{
    public sealed class RoomEquipment
    {
       

        public int Id { get; set; }
       public bool Refrigerator { get; set; }
       public bool Microwave { get; set; }
       public bool InternetAccess { get; set; }
       public bool AirConditioning { get; set; }
       public bool Heating { get; set; }
       public bool Bathroom { get; set; }
       public int RoomId { get; set; }
       public Room Room { get; set; }
       public DateTime CreateDate { get; set; }
       public DateTime UpdateDate { get; set; }

        public RoomEquipment(int id, bool refrigerator, bool microwave, bool internetAccess, bool airConditioning, bool heating, bool bathroom, Room room, DateTime createDate, DateTime updateDate)
        {
            Id = id;
            Refrigerator = refrigerator;
            Microwave = microwave;
            InternetAccess = internetAccess;
            AirConditioning = airConditioning;
            Heating = heating;
            Bathroom = bathroom;
            Room = room;
            CreateDate = createDate;
            UpdateDate = updateDate;
        }
    }
}
