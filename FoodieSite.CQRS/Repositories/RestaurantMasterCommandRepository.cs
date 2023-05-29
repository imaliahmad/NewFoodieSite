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
    public class RestaurantMasterCommandRepository : IRestaurantMasterCommandRepository
    {
        private readonly EFCoreDbContext context;

        public RestaurantMasterCommandRepository(EFCoreDbContext _context)
        {
            context = _context;
        }

        // Deletes a restaurant master record by ID
        public async Task<JsonResponse> Delete(Guid id) //200
        {
            var obj = await context.tblRestaurantMaster.Where(x => x.Id == id && x.IsActive == true).FirstOrDefaultAsync();
            if (obj == null)
            {
                return new JsonResponse() { IsSuccess = false, Message = "Record not found.", StatusCode = 404 };
            }
            // Soft delete by setting IsActive flag to false
            obj.IsActive = false;
            context.tblRestaurantMaster.Update(obj);
            await context.SaveChangesAsync();

            return new JsonResponse() { IsSuccess = true, Message = "Record deleted successfully.", StatusCode = 200 };
        }

        // Inserts a new restaurant master record
        public async Task<JsonResponse> Insert(RestaurantMaster obj)
        {
            obj.IsActive = true;
            obj.CreatedDate = DateTime.UtcNow;
            obj.CreatedBy = new Guid("787185c5-bc39-41a2-41f6-08db607bb31e");
            context.tblRestaurantMaster.Add(obj);
            await context.SaveChangesAsync();

            return new JsonResponse() { IsSuccess = true, Data = obj, Message = "Record saved successfully.", StatusCode = 200 };
        }

        // Updates an existing restaurant master record
        public async Task<JsonResponse> Update(RestaurantMaster obj)
        {
            var existingRecord = await context.tblRestaurantMaster
                .FirstOrDefaultAsync(x => x.Id == obj.Id && x.IsActive == true);

            if (existingRecord == null)
            {
                return new JsonResponse()
                {
                    IsSuccess = false,
                    Message = "Record not found.",
                    StatusCode = 404
                };
            }

            // Detach the existing tracked entity
            context.Entry(existingRecord).State = EntityState.Detached;
            obj.IsActive = true;
            obj.ModifiedDate = DateTime.UtcNow;
            obj.ModifiedBy = new Guid("a7a18502-bc39-41a2-41f6-08db607bb31e");

            context.tblRestaurantMaster.Update(obj);
            await context.SaveChangesAsync();

            return new JsonResponse()
            {
                IsSuccess = true,
                Message = "Record updated successfully.",
                StatusCode = 200
            };
        }

    }
}
