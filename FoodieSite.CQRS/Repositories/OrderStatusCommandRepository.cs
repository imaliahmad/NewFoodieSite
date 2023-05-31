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
    /// Repository for performing CRUD operations on order status records.
    /// </summary>
    public class OrderStatusCommandRepository : IOrderStatusCommandRepository
    {
        private readonly EFCoreDbContext context;

        public OrderStatusCommandRepository(EFCoreDbContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// Deletes an order status record by ID.
        /// </summary>
        /// <param name="id">The ID of the order status record to delete.</param>
        /// <returns>A <see cref="JsonResponse"/> indicating the result of the delete operation.</returns>
        public async Task<JsonResponse> Delete(Guid id)
        {
            var obj = await context.tblOrderStatus.Where(x => x.Id == id && x.IsActive == true).FirstOrDefaultAsync();
            if (obj == null)
            {
                return new JsonResponse() { IsSuccess = false, Message = "Record not found.", StatusCode = 404 };
            }
            // Soft delete by setting IsActive flag to false
            obj.IsActive = false;
            context.tblOrderStatus.Update(obj);
            await context.SaveChangesAsync();

            return new JsonResponse() { IsSuccess = true, Message = "Record deleted successfully.", StatusCode = 200 };
        }

        /// <summary>
        /// Inserts a new order status record.
        /// </summary>
        /// <param name="obj">The order status object to insert.</param>
        /// <returns>A <see cref="JsonResponse"/> containing the inserted order status record.</returns>
        public async Task<JsonResponse> Insert(OrderStatus obj)
        {
            obj.IsActive = true;
            obj.CreatedDate = DateTime.UtcNow;
            obj.CreatedBy = new Guid("a7a18502-bc39-41a2-41f6-08db607bb31e");
            context.tblOrderStatus.Add(obj);
            await context.SaveChangesAsync();

            return new JsonResponse() { IsSuccess = true, Data = obj, Message = "Record saved successfully.", StatusCode = 200 };
        }

        /// <summary>
        /// Updates an existing order status record.
        /// </summary>
        /// <param name="obj">The updated order status object.</param>
        /// <returns>A <see cref="JsonResponse"/> indicating the result of the update operation.</returns>
        public async Task<JsonResponse> Update(OrderStatus obj)
        {
            var record = await context.tblOrderStatus.Where(x => x.Id == obj.Id && x.IsActive == true).FirstOrDefaultAsync();
            if (record == null)
            {
                return new JsonResponse() { IsSuccess = false, Message = "Record not found.", StatusCode = 404 };
            }
            obj.ModifiedDate = DateTime.UtcNow;
            obj.ModifiedBy = new Guid("a7a18502-bc39-41a2-41f6-08db607bb31e");
            context.tblOrderStatus.Update(obj);
            await context.SaveChangesAsync();

            return new JsonResponse() { IsSuccess = true, Message = "Record updated successfully.", StatusCode = 200 };
        }
    }
}
