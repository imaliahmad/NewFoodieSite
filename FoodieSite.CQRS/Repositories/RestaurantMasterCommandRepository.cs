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
    /// Repository for performing insert, update and delete operations on restaurant master records.
    /// </summary>
    public class RestaurantMasterCommandRepository : IRestaurantMasterCommandRepository
    {
        private readonly EFCoreDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestaurantMasterCommandRepository"/> class.
        /// </summary>
        /// <param name="_context">The EF Core database context.</param>
        public RestaurantMasterCommandRepository(EFCoreDbContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// Deletes a restaurant master record by ID.
        /// </summary>
        /// <param name="id">The ID of the restaurant master record to delete.</param>
        /// <returns>A <see cref="JsonResponse"/> indicating the result of the deletion operation.</returns>
        public async Task<JsonResponse> Delete(Guid id)
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
            obj.StoreMaster = null;
            return new JsonResponse() { IsSuccess = true, Message = "Record deleted successfully.", StatusCode = 200 };
        }

        /// <summary>
        /// Inserts a new restaurant master record.
        /// </summary>
        /// <param name="obj">The restaurant master object to insert.</param>
        /// <returns>A <see cref="JsonResponse"/> indicating the result of the insertion operation.</returns>
        public async Task<JsonResponse> Insert(RestaurantMaster obj)
        {
            obj.IsActive = true;
            obj.CreatedDate = DateTime.UtcNow;
            obj.CreatedBy = new Guid("787185c5-bc39-41a2-41f6-08db607bb31e");
            context.tblRestaurantMaster.Add(obj);
            await context.SaveChangesAsync();
            obj.StoreMaster = null;
            return new JsonResponse() { IsSuccess = true, Data = obj, Message = "Record saved successfully.", StatusCode = 200 };
        }

        /// <summary>
        /// Updates an existing restaurant master record.
        /// </summary>
        /// <param name="obj">The updated restaurant master object.</param>
        /// <returns>A <see cref="JsonResponse"/> indicating the result of the update operation.</returns>
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
            obj.StoreMaster = null;
            return new JsonResponse()
            {
                IsSuccess = true,
                Data = obj,
                Message = "Record updated successfully.",
                StatusCode = 200
            };
        }

    }
}
