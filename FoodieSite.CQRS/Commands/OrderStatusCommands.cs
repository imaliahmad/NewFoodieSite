using FoodieSite.CQRS.Commands.interfaces;
using FoodieSite.CQRS.Models;
using FoodieSite.CQRS.Repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Commands
{
    /// <summary>
    /// Implementation of commands for managing OrderStatus entities.
    /// </summary>
    public class OrderStatusCommands : IOrderStatusCommands
    {
        private readonly IOrderStatusCommandRepository repository;

        /// <summary>
        /// Initializes a new instance of the OrderStatusCommands class.
        /// </summary>
        /// <param name="_repository">The repository for OrderStatus commands.</param>
        public OrderStatusCommands(IOrderStatusCommandRepository _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// Deletes an OrderStatus entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the OrderStatus entity to delete.</param>
        /// <returns>A task representing the asynchronous operation, returning the JSON response.</returns>
        public async Task<JsonResponse> Delete(Guid id)
        {
            return await repository.Delete(id);
        }

        /// <summary>
        /// Inserts a new OrderStatus entity.
        /// </summary>
        /// <param name="obj">The OrderStatus entity to insert.</param>
        /// <returns>A task representing the asynchronous operation, returning the JSON response.</returns>
        public async Task<JsonResponse> Insert(OrderStatus obj)
        {
            return await repository.Insert(obj);
        }

        /// <summary>
        /// Updates an existing OrderStatus entity.
        /// </summary>
        /// <param name="obj">The OrderStatus entity to update.</param>
        /// <returns>A task representing the asynchronous operation, returning the JSON response.</returns>
        public async Task<JsonResponse> Update(OrderStatus obj)
        {
            return await repository.Update(obj);
        }
    }
}
