using FoodieSite.CQRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Repositories.interfaces
{
    public interface ICategoryMasterCommandRepository
    {
        Task<JsonResponse> Insert(CategoryMaster obj);
        Task<JsonResponse> Update(CategoryMaster obj);
        Task<JsonResponse> Delete(Guid id);
    }
}
