using FoodieSite.CQRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Repositories.interfaces
{
    public interface IStoreMasterQueryRepository
    {
        Task<JsonResponse> GetAll();
        Task<JsonResponse> GetById(Guid id);
        Task<JsonResponse> GetByRestaurantId(Guid id);
    }
}
