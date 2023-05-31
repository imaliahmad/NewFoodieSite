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
    /// Implementation of commands for managing OrderDetails entities.
    /// </summary>
    public class OrderDetailsCommands : IOrderDetailsCommands
    {
        private readonly IOrderDetailsCommandRepository repository;

        /// <summary>
        /// Initializes a new instance of the OrderDetailsCommands class.
        /// </summary>
        /// <param name="_repository">The repository for OrderDetails commands.</param>
        public OrderDetailsCommands(IOrderDetailsCommandRepository _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// Deletes an OrderDetails entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the OrderDetails entity to delete.</param>
        /// <returns>A task representing the asynchronous operation, returning the JSON response.</returns>
        public async Task<JsonResponse> Delete(Guid id)
        {
            return await repository.Delete(id);
        }

        /// <summary>
        /// Inserts a new OrderDetails entity.
        /// </summary>
        /// <param name="obj">The OrderDetails entity to insert.</param>
        /// <returns>A task representing the asynchronous operation, returning the JSON response.</returns>
        public async Task<JsonResponse> Insert(OrderDetails obj)
        {
            return await repository.Insert(obj);
        }

        /// <summary>
        /// Updates an existing OrderDetails entity.
        /// </summary>
        /// <param name="obj">The OrderDetails entity to update.</param>
        /// <returns>A task representing the asynchronous operation, returning the JSON response.</returns>
        public async Task<JsonResponse> Update(OrderDetails obj)
        {
            return await repository.Update(obj);
        }
    }
}
