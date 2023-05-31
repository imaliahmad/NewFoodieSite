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
    /// Represents the implementation of payment master queries.
    /// </summary>
    public class PaymentMasterQueries : IPaymentMasterQueries
    {
        private readonly IPaymentMasterQueryRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentMasterQueries"/> class.
        /// </summary>
        /// <param name="_repository">The payment master query repository.</param>
        public PaymentMasterQueries(IPaymentMasterQueryRepository _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// Retrieves all payment details.
        /// </summary>
        /// <returns>A <see cref="Task{JsonResponse}"/> representing the asynchronous operation.</returns>
        public async Task<JsonResponse> GetAll()
        {
            return await repository.GetAll();
        }

        /// <summary>
        /// Retrieves payment details by its ID.
        /// </summary>
        /// <param name="id">The ID of the payment.</param>
        /// <returns>A <see cref="Task{JsonResponse}"/> representing the asynchronous operation.</returns>
        public async Task<JsonResponse> GetById(Guid id)
        {
            return await repository.GetById(id);
        }
    }
}
