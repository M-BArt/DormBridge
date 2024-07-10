using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormBridge.Application.Abstractions
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : class, IQuery<TResult>
    {
        Task<TResult> HandleAsyncAction(TQuery query);

    }
}
