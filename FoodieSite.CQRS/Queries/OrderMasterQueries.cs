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
    /// Represents the implementation of order details queries.
    /// </summary>
    public class OrderMasterQueries : IOrderDetailsQueries
    {
        private readonly IOrderMasterQueryRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderMasterQueries"/> class.
        /// </summary>
        /// <param name="_repository">The order master query repository.</param>
        public OrderMasterQueries(IOrderMasterQueryRepository _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// Retrieves all order details.
        /// </summary>
        /// <returns>A <see cref="Task{JsonResponse}"/> representing the asynchronous operation.</returns>
        public async Task<JsonResponse> GetAll()
        {
            return await repository.GetAll();
        }

        /// <summary>
        /// Retrieves order details by its ID.
        /// </summary>
        /// <param name="id">The ID of the order.</param>
        /// <returns>A <see cref="Task{JsonResponse}"/> representing the asynchronous operation.</returns>
        public async Task<JsonResponse> GetById(Guid id)
        {
            return await repository.GetById(id);
        }
    }
}
