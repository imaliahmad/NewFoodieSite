using FoodieSite.CQRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Queries.interfaces
{
    public interface IOrderMasterQueries
    {
        Task<JsonResponse> GetAll();
        Task<JsonResponse> GetById(Guid id);
    }
}
