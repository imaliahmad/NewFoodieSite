using FoodieSite.CQRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Repositories.interfaces
{
    public interface IOrderStatusCommandRepository
    {
        Task<JsonResponse> Insert(OrderStatus obj);
        Task<JsonResponse> Update(OrderStatus obj);
        Task<JsonResponse> Delete(Guid id);
    }
}
