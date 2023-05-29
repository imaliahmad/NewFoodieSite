using FoodieSite.CQRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Commands.interfaces
{
    public interface ICustomerMasterCommands
    {
        Task<JsonResponse> Insert(CustomerMaster obj);
        Task<JsonResponse> Update(CustomerMaster obj);
        Task<JsonResponse> Delete(Guid id);
    }
}
