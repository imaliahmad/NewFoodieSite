using FoodieSite.CQRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Repositories.interfaces
{
    public interface IRestaurantMasterQueryRepository
    {
        Task<JsonResponse> GetAll();
        Task<JsonResponse> GetByRestaurantId(Guid id);
        Task<JsonResponse> GetByCompanyId(Guid id);
    }
}
