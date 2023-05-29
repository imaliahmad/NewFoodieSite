using FoodieSite.CQRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Repositories.interfaces
{
    public interface IStoreMasterCommandRepository
    {
        Task<JsonResponse> Insert(StoreMaster obj);
        Task<JsonResponse> Update(StoreMaster obj);
        Task<JsonResponse> Delete(Guid id);
    }
}
