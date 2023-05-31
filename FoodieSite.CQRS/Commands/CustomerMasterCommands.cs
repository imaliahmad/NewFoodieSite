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
    /// Implementation of commands for managing CustomerMaster entities.
    /// </summary>
    public class CustomerMasterCommands : ICustomerMasterCommands
    {
        private readonly ICustomerMasterCommandRepository repository;

        /// <summary>
        /// Initializes a new instance of the CustomerMasterCommands class.
        /// </summary>
        /// <param name="_repository">The repository for CustomerMaster commands.</param>
        public CustomerMasterCommands(ICustomerMasterCommandRepository _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// Deletes a CustomerMaster entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the CustomerMaster entity to delete.</param>
        /// <returns>A task representing the asynchronous operation, returning the JSON response.</returns>
        public async Task<JsonResponse> Delete(Guid id)
        {
            return await repository.Delete(id);
        }

        /// <summary>
        /// Inserts a new CustomerMaster entity.
        /// </summary>
        /// <param name="obj">The CustomerMaster entity to insert.</param>
        /// <returns>A task representing the asynchronous operation, returning the JSON response.</returns>
        public async Task<JsonResponse> Insert(CustomerMaster obj)
        {
            return await repository.Insert(obj);
        }

        /// <summary>
        /// Updates an existing CustomerMaster entity.
        /// </summary>
        /// <param name="obj">The CustomerMaster entity to update.</param>
        /// <returns>A task representing the asynchronous operation, returning the JSON response.</returns>
        public async Task<JsonResponse> Update(CustomerMaster obj)
        {
            return await repository.Update(obj);
        }
    }
}
