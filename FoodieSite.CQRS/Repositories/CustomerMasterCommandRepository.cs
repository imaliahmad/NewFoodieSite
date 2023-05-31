using FoodieSite.CQRS.Data;
using FoodieSite.CQRS.Models;
using FoodieSite.CQRS.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Repositories
{
    /// <summary>
    /// Repository for performing insert, update and delete operations related to CustomerMaster entities.
    /// </summary>
    public class CustomerMasterCommandRepository : ICustomerMasterCommandRepository
    {
        private readonly EFCoreDbContext context;

        public CustomerMasterCommandRepository(EFCoreDbContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// Deletes a customer by ID.
        /// </summary>
        /// <param name="id">The ID of the customer to delete.</param>
        /// <returns>A <see cref="JsonResponse"/> indicating the success or failure of the operation.</returns>
        public async Task<JsonResponse> Delete(Guid id)
        {
            var obj = await context.tblCustomerMaster.Where(x => x.Id == id && x.IsActive == true).FirstOrDefaultAsync();
            if (obj == null)
            {
                return new JsonResponse() { IsSuccess = false, Message = "Record not found.", StatusCode = 404 };
            }
            // Soft delete by setting IsActive flag to false
            obj.IsActive = false;
            context.tblCustomerMaster.Update(obj);
            await context.SaveChangesAsync();

            return new JsonResponse() { IsSuccess = true, Message = "Record deleted successfully.", StatusCode = 200 };
        }

        /// <summary>
        /// Inserts a new customer.
        /// </summary>
        /// <param name="obj">The customer object to insert.</param>
        /// <returns>A <see cref="JsonResponse"/> containing the inserted customer and the status of the operation.</returns>
        public async Task<JsonResponse> Insert(CustomerMaster obj)
        {
            obj.IsActive = true;
            obj.CreatedDate = DateTime.UtcNow;
            obj.CreatedBy = new Guid("a7a18502-bc39-41a2-41f6-08db607bb31e");
            context.tblCustomerMaster.Add(obj);
            await context.SaveChangesAsync();

            return new JsonResponse() { IsSuccess = true, Data = obj, Message = "Record saved successfully.", StatusCode = 200 };
        }

        /// <summary>
        /// Updates an existing customer.
        /// </summary>
        /// <param name="obj">The customer object with updated values.</param>
        /// <returns>A <see cref="JsonResponse"/> indicating the success or failure of the update operation.</returns>
        public async Task<JsonResponse> Update(CustomerMaster obj)
        {
            var record = await context.tblCustomerMaster.Where(x => x.Id == obj.Id && x.IsActive == true).FirstOrDefaultAsync();
            if (record == null)
            {
                return new JsonResponse() { IsSuccess = false, Message = "Record not found.", StatusCode = 404 };
            }
            obj.ModifiedDate = DateTime.UtcNow;
            obj.ModifiedBy = new Guid("a7a18502-bc39-41a2-41f6-08db607bb31e");
            context.tblCustomerMaster.Update(obj);
            await context.SaveChangesAsync();

            return new JsonResponse() { IsSuccess = true, Message = "Record updated successfully.", StatusCode = 200 };
        }
    }
}
