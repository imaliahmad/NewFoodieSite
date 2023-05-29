using FoodieSite.CQRS.Models;
using FoodieSite.CQRS.Queries.interfaces;
using FoodieSite.CQRS.Repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Queries
{
    public class RestaurantMasterQueries : IRestaurantMasterQueries
	{
        private readonly IRestaurantMasterQueryRepository repository;
        public RestaurantMasterQueries(IRestaurantMasterQueryRepository _repository)
        {
            repository = _repository;
        }
        public async Task<JsonResponse> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<JsonResponse> GetById(Guid id)
        {
            return await repository.GetById(id);
        }
    }
}
