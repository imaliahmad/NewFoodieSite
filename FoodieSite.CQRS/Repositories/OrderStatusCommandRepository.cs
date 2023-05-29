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
    public class OrderStatusCommandRepository : IOrderStatusCommandRepository
    {
        private readonly EFCoreDbContext context;

        public OrderStatusCommandRepository(EFCoreDbContext _context)
        {
            context = _context;
        }

        // Deletes an order status record by ID
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

        // Inserts a new order status record
        public async Task<JsonResponse> Insert(OrderStatus obj)
        {
            obj.IsActive = true;
            obj.CreatedDate = DateTime.UtcNow;
            obj.CreatedBy = new Guid("a7a18502-bc39-41a2-41f6-08db607bb31e");
            context.tblOrderStatus.Add(obj);
            await context.SaveChangesAsync();

            return new JsonResponse() { IsSuccess = true, Data = obj, Message = "Record saved successfully.", StatusCode = 200 };
        }

        // Updates an existing order status record
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
