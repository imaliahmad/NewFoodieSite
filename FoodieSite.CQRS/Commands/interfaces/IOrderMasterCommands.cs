using FoodieSite.CQRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Commands.interfaces
{
    public interface IOrderMasterCommands
    {
        Task<JsonResponse> Insert(OrderMaster obj);
        Task<JsonResponse> Update(OrderMaster obj);
        Task<JsonResponse> Delete(Guid id);
    }
}
