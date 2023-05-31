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
    /// Repository for performing insert, update and delete operations on store master records.
    /// </summary>
    public class StoreMasterCommandRepository : IStoreMasterCommandRepository
    {
        private readonly EFCoreDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreMasterCommandRepository"/> class.
        /// </summary>
        /// <param name="_context">The EF Core database context.</param>
        public StoreMasterCommandRepository(EFCoreDbContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// Deletes a store master record by ID.
        /// </summary>
        /// <param name="id">The ID of the store master record to delete.</param>
        /// <returns>A <see cref="JsonResponse"/> indicating the result of the deletion operation.</returns>
        public async Task<JsonResponse> Delete(Guid id)
        {
            var obj = await context.tblStoreMaster.Where(x => x.Id == id && x.IsActive == true).FirstOrDefaultAsync();
            if (obj == null)
            {
                return new JsonResponse() { IsSuccess = false, Message = "Record not found.", StatusCode = 404 };
            }
            // Soft delete by setting IsActive flag to false
            obj.IsActive = false;
            context.tblStoreMaster.Update(obj);
            await context.SaveChangesAsync();
            obj.OrderMaster = null;
            obj.RestaurantMaster = null;
            obj.CategoryMaster = null;
            return new JsonResponse() { IsSuccess = true, Message = "Record deleted successfully.", StatusCode = 200 };
        }

        /// <summary>
        /// Inserts a new store master record.
        /// </summary>
        /// <param name="obj">The store master object to insert.</param>
        /// <returns>A <see cref="JsonResponse"/> indicating the result of the insertion operation.</returns>
        public async Task<JsonResponse> Insert(StoreMaster obj)
        {
            obj.IsActive = true;
            obj.CreatedDate = DateTime.UtcNow;
            obj.CreatedBy = new Guid("a7a18502-bc39-41a2-41f6-08db607bb31e");
            context.tblStoreMaster.Add(obj);
            await context.SaveChangesAsync();
            obj.OrderMaster = null;
            obj.RestaurantMaster = null;
            obj.CategoryMaster = null;
            return new JsonResponse() { IsSuccess = true, Data = obj, Message = "Record saved successfully.", StatusCode = 200 };
        }

        /// <summary>
        /// Updates an existing store master record.
        /// </summary>
        /// <param name="obj">The updated store master object.</param>
        /// <returns>A <see cref="JsonResponse"/> indicating the result of the update operation.</returns>
        public async Task<JsonResponse> Update(StoreMaster obj)
        {
            var record = await context.tblStoreMaster.Where(x => x.Id == obj.Id && x.IsActive).FirstOrDefaultAsync();
            if (record == null)
            {
                return new JsonResponse { IsSuccess = false, Message = "Record not found.", StatusCode = 404 };
            }

            record.ModifiedDate = DateTime.UtcNow;
            record.ModifiedBy = new Guid("a7a18502-bc39-41a2-41f6-08db607bb31e");
            context.tblStoreMaster.Update(record);
            await context.SaveChangesAsync();

            record.OrderMaster = null;
            record.RestaurantMaster = null;
            record.CategoryMaster = null;

            return new JsonResponse { IsSuccess = true, Message = "Record updated successfully.", StatusCode = 200 };

        }
    }
}
