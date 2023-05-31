using FoodieSite.CQRS.Data;
using FoodieSite.CQRS.Models;
using FoodieSite.CQRS.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Repositories
{
    /// <summary>
    /// Repository for querying payment master records.
    /// </summary>
    public class PaymentMasterQueryRepository : IPaymentMasterQueryRepository
    {
        private readonly EFCoreDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentMasterQueryRepository"/> class.
        /// </summary>
        /// <param name="_context">The EF Core database context.</param>
        public PaymentMasterQueryRepository(EFCoreDbContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// Retrieves all payment master records.
        /// </summary>
        /// <returns>A <see cref="JsonResponse"/> containing the payment master records.</returns>
        public async Task<JsonResponse> GetAll()
        {
            var list = await context.tblPaymentMaster.Where(x => x.IsActive == true).ToListAsync();
            return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = list };
        }

        /// <summary>
        /// Retrieves payment master records by order ID.
        /// </summary>
        /// <param name="id">The ID of the order.</param>
        /// <returns>A <see cref="JsonResponse"/> containing the payment master records for the specified order ID.</returns>
        public async Task<JsonResponse> GetByOrderId(Guid id)
        {
            var obj = await context.tblPaymentMaster.Where(x => x.OrderId == id && x.IsActive == true).ToListAsync();
            if (obj == null)
            {
                return new JsonResponse() { IsSuccess = false, StatusCode = 404, Message = "Record Not Found." };
            }
            return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = obj };
        }

        /// <summary>
        /// Retrieves a payment master record by ID.
        /// </summary>
        /// <param name="id">The ID of the payment master record.</param>
        /// <returns>A <see cref="JsonResponse"/> containing the payment master record with the specified ID.</returns>
        public async Task<JsonResponse> GetById(Guid id)
        {
            var obj = await context.tblPaymentMaster.Where(x => x.Id == id && x.IsActive == true).FirstOrDefaultAsync();
            if (obj == null)
            {
                return new JsonResponse() { IsSuccess = false, StatusCode = 404, Message = "Record Not Found." };
            }

            return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = obj };
        }
    }
}
