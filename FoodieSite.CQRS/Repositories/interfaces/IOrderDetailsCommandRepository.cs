using FoodieSite.CQRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Repositories.interfaces
{
    public interface IOrderDetailsCommandRepository
    {
        Task<JsonResponse> Insert(OrderDetails obj);
        Task<JsonResponse> Update(OrderDetails obj);
        Task<JsonResponse> Delete(Guid id);
    }
}
