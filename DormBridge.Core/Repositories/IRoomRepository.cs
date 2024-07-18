﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormBridge.Domain.Entities;

namespace DormBridge.Domain.Repositories
{
    public interface IRoomRepository
    {
        Task AddRoom(Room room);
    }
}
