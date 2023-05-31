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
    /// <summary>
    /// Represents the implementation of store master queries.
    /// </summary>
    public class StoreMasterQueries : IStoreMasterQueries
    {
        private readonly IStoreMasterQueryRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreMasterQueries"/> class.
        /// </summary>
        /// <param name="_repository">The store master query repository.</param>
        public StoreMasterQueries(IStoreMasterQueryRepository _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// Retrieves all store details.
        /// </summary>
        /// <returns>A <see cref="Task{JsonResponse}"/> representing the asynchronous operation.</returns>
        public async Task<JsonResponse> GetAll()
        {
            return await repository.GetAll();
        }

        /// <summary>
        /// Retrieves store details by its ID.
        /// </summary>
        /// <param name="id">The ID of the store.</param>
        /// <returns>A <see cref="Task{JsonResponse}"/> representing the asynchronous operation.</returns>
        public async Task<JsonResponse> GetById(Guid id)
        {
            return await repository.GetById(id);
        }
    }
}
