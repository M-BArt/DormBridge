using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormBridge.Application.Abstractions;
using DormBridge.Application.DTOs.User;

namespace DormBridge.Application.Queries
{
    public class NullQuery<T> : IQuery<T>
    {
    }
}
