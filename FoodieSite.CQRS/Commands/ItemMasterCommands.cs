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
    /// Implementation of commands for managing ItemMaster entities.
    /// </summary>
    public class ItemMasterCommands : IItemMasterCommands
    {
        private readonly IItemMasterCommandRepository repository;

        /// <summary>
        /// Initializes a new instance of the ItemMasterCommands class.
        /// </summary>
        /// <param name="_repository">The repository for ItemMaster commands.</param>
        public ItemMasterCommands(IItemMasterCommandRepository _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// Deletes an ItemMaster entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the ItemMaster entity to delete.</param>
        /// <returns>A task representing the asynchronous operation, returning the JSON response.</returns>
        public async Task<JsonResponse> Delete(Guid id)
        {
            return await repository.Delete(id);
        }

        /// <summary>
        /// Inserts a new ItemMaster entity.
        /// </summary>
        /// <param name="obj">The ItemMaster entity to insert.</param>
        /// <returns>A task representing the asynchronous operation, returning the JSON response.</returns>
        public async Task<JsonResponse> Insert(ItemMaster obj)
        {
            return await repository.Insert(obj);
        }

        /// <summary>
        /// Updates an existing ItemMaster entity.
        /// </summary>
        /// <param name="obj">The ItemMaster entity to update.</param>
        /// <returns>A task representing the asynchronous operation, returning the JSON response.</returns>
        public async Task<JsonResponse> Update(ItemMaster obj)
        {
            return await repository.Update(obj);
        }
    }
}
