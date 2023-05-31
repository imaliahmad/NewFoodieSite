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
    /// Implementation of commands for managing PaymentMaster entities.
    /// </summary>
    public class PaymentMasterCommands : IPaymentMasterCommands
    {
        private readonly IPaymentMasterCommandRepository repository;

        /// <summary>
        /// Initializes a new instance of the PaymentMasterCommands class.
        /// </summary>
        /// <param name="_repository">The repository for PaymentMaster commands.</param>
        public PaymentMasterCommands(IPaymentMasterCommandRepository _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// Deletes a PaymentMaster entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the PaymentMaster entity to delete.</param>
        /// <returns>A task representing the asynchronous operation, returning the JSON response.</returns>
        public async Task<JsonResponse> Delete(Guid id)
        {
            return await repository.Delete(id);
        }

        /// <summary>
        /// Inserts a new PaymentMaster entity.
        /// </summary>
        /// <param name="obj">The PaymentMaster entity to insert.</param>
        /// <returns>A task representing the asynchronous operation, returning the JSON response.</returns>
        public async Task<JsonResponse> Insert(PaymentMaster obj)
        {
            return await repository.Insert(obj);
        }

        /// <summary>
        /// Updates an existing PaymentMaster entity.
        /// </summary>
        /// <param name="obj">The PaymentMaster entity to update.</param>
        /// <returns>A task representing the asynchronous operation, returning the JSON response.</returns>
        public async Task<JsonResponse> Update(PaymentMaster obj)
        {
            return await repository.Update(obj);
        }
    }
}
