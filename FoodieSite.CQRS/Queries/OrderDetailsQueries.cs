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
    /// Represents a class that implements the queries for the OrderDetails entity.
    /// </summary>
    public class OrderDetailsQueries : IOrderDetailsQueries
    {
        private readonly IOrderDetailsQueryRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderDetailsQueries"/> class.
        /// </summary>
        /// <param name="_repository">The repository for OrderDetails queries.</param>
        public OrderDetailsQueries(IOrderDetailsQueryRepository _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// Gets all the OrderDetails entities.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation. The task result contains the JSON response.</returns>
        public async Task<JsonResponse> GetAll()
        {
            return await repository.GetAll();
        }

        /// <summary>
        /// Gets an OrderDetails entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the OrderDetails entity.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation. The task result contains the JSON response.</returns>
        public async Task<JsonResponse> GetById(Guid id)
        {
            return await repository.GetById(id);
        }
    }
}
