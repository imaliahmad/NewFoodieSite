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
    /// Represents the implementation of order status queries.
    /// </summary>
    public class OrderStatusQueries : IOrderStatusQueries
    {
        private readonly IOrderStatusQueryRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderStatusQueries"/> class.
        /// </summary>
        /// <param name="_repository">The order status query repository.</param>
        public OrderStatusQueries(IOrderStatusQueryRepository _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// Retrieves all order statuses.
        /// </summary>
        /// <returns>A <see cref="Task{JsonResponse}"/> representing the asynchronous operation.</returns>
        public async Task<JsonResponse> GetAll()
        {
            return await repository.GetAll();
        }

        /// <summary>
        /// Retrieves order status by its ID.
        /// </summary>
        /// <param name="id">The ID of the order status.</param>
        /// <returns>A <see cref="Task{JsonResponse}"/> representing the asynchronous operation.</returns>
        public async Task<JsonResponse> GetById(Guid id)
        {
            return await repository.GetById(id);
        }
    }
}
