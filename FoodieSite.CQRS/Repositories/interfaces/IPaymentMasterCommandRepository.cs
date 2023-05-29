using FoodieSite.CQRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Repositories.interfaces
{
    public interface IPaymentMasterCommandRepository 
    {
        Task<JsonResponse> Insert(PaymentMaster obj);
        Task<JsonResponse> Update(PaymentMaster obj);
        Task<JsonResponse> Delete(Guid id);
    }
}
