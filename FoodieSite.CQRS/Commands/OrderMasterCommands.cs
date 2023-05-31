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
    /// Implementation of commands for managing OrderMaster entities.
    /// </summary>
    public class OrderMasterCommands : IOrderMasterCommands
    {
        private readonly IOrderMasterCommandRepository repository;

        /// <summary>
        /// Initializes a new instance of the OrderMasterCommands class.
        /// </summary>
        /// <param name="_repository">The repository for OrderMaster commands.</param>
        public OrderMasterCommands(IOrderMasterCommandRepository _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// Deletes an OrderMaster entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the OrderMaster entity to delete.</param>
        /// <returns>A task representing the asynchronous operation, returning the JSON response.</returns>
        public async Task<JsonResponse> Delete(Guid id)
        {
            return await repository.Delete(id);
        }

        /// <summary>
        /// Inserts a new OrderMaster entity.
        /// </summary>
        /// <param name="obj">The OrderMaster entity to insert.</param>
        /// <returns>A task representing the asynchronous operation, returning the JSON response.</returns>
        public async Task<JsonResponse> Insert(OrderMaster obj)
        {
            return await repository.Insert(obj);
        }

        /// <summary>
        /// Updates an existing OrderMaster entity.
        /// </summary>
        /// <param name="obj">The OrderMaster entity to update.</param>
        /// <returns>A task representing the asynchronous operation, returning the JSON response.</returns>
        public async Task<JsonResponse> Update(OrderMaster obj)
        {
            return await repository.Update(obj);
        }
    }
}
