using FoodieSite.CQRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Repositories.interfaces
{
    public interface IOrderMasterQueryRepository
    {
        Task<JsonResponse> GetAll();
        Task<JsonResponse> GetById(Guid id);
        Task<JsonResponse> GetByStoreId(Guid id);
        Task<JsonResponse> GetByCustomerId(Guid id);
    }
}
