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
    /// Repository for performing CRUD operations on payment master records.
    /// </summary>
    public class PaymentMasterCommandRepository : IPaymentMasterCommandRepository
    {
        private readonly EFCoreDbContext context;

        public PaymentMasterCommandRepository(EFCoreDbContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// Deletes a payment master record by ID.
        /// </summary>
        /// <param name="id">The ID of the payment master record.</param>
        /// <returns>A <see cref="JsonResponse"/> indicating the result of the operation.</returns>
        public async Task<JsonResponse> Delete(Guid id)
        {
            var obj = await context.tblPaymentMaster.Where(x => x.Id == id && x.IsActive == true).FirstOrDefaultAsync();
            if (obj == null)
            {
                return new JsonResponse() { IsSuccess = false, Message = "Record not found.", StatusCode = 404 };
            }
            // Soft delete by setting IsActive flag to false
            obj.IsActive = false;
            context.tblPaymentMaster.Update(obj);
            await context.SaveChangesAsync();

            return new JsonResponse() { IsSuccess = true, Message = "Record deleted successfully.", StatusCode = 200 };
        }

        /// <summary>
        /// Inserts a new payment master record.
        /// </summary>
        /// <param name="obj">The payment master object to be inserted.</param>
        /// <returns>A <see cref="JsonResponse"/> containing the inserted payment master record.</returns>
        public async Task<JsonResponse> Insert(PaymentMaster obj)
        {
            obj.IsActive = true;
            obj.CreatedDate = DateTime.UtcNow;
            obj.CreatedBy = new Guid("a7a18502-bc39-41a2-41f6-08db607bb31e");
            context.tblPaymentMaster.Add(obj);
            await context.SaveChangesAsync();

            return new JsonResponse() { IsSuccess = true, Data = obj, Message = "Record saved successfully.", StatusCode = 200 };
        }

        /// <summary>
        /// Updates an existing payment master record.
        /// </summary>
        /// <param name="obj">The payment master object with updated values.</param>
        /// <returns>A <see cref="JsonResponse"/> indicating the result of the operation.</returns>
        public async Task<JsonResponse> Update(PaymentMaster obj)
        {
            var record = await context.tblPaymentMaster.Where(x => x.Id == obj.Id && x.IsActive == true).FirstOrDefaultAsync();
            if (record == null)
            {
                return new JsonResponse() { IsSuccess = false, Message = "Record not found.", StatusCode = 404 };
            }
            obj.ModifiedDate = DateTime.UtcNow;
            obj.ModifiedBy = new Guid("a7a18502-bc39-41a2-41f6-08db607bb31e");
            context.tblPaymentMaster.Update(obj);
            await context.SaveChangesAsync();

            return new JsonResponse() { IsSuccess = true, Message = "Record updated successfully.", StatusCode = 200 };
        }
    }
}
