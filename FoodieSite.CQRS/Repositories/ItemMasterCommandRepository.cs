using FoodieSite.CQRS.Data;
using FoodieSite.CQRS.Models;
using FoodieSite.CQRS.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Repositories
{
    /// <summary>
    /// Repository for performing CRUD operations related to ItemMaster entities.
    /// </summary>
    public class ItemMasterCommandRepository : IItemMasterCommandRepository
    {
        private readonly EFCoreDbContext context;

        public ItemMasterCommandRepository(EFCoreDbContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// Deletes an item by ID.
        /// </summary>
        /// <param name="id">The ID of the item to delete.</param>
        /// <returns>A <see cref="JsonResponse"/> indicating the success or failure of the operation.</returns>
        public async Task<JsonResponse> Delete(Guid id)
        {
            var obj = await context.tblItemMaster.Where(x => x.Id == id && x.IsActive == true).FirstOrDefaultAsync();
            if (obj == null)
            {
                return new JsonResponse() { IsSuccess = false, Message = "Record not found.", StatusCode = 404 };
            }
            // Soft delete by setting IsActive flag to false
            obj.IsActive = false;
            context.tblItemMaster.Update(obj);
            await context.SaveChangesAsync();

            return new JsonResponse() { IsSuccess = true, Message = "Record deleted successfully.", StatusCode = 200 };
        }

        /// <summary>
        /// Inserts a new item.
        /// </summary>
        /// <param name="obj">The item object to insert.</param>
        /// <returns>A <see cref="JsonResponse"/> containing the inserted item and the status of the operation.</returns>
        public async Task<JsonResponse> Insert(ItemMaster obj)
        {
            obj.IsActive = true;
            obj.CreatedDate = DateTime.UtcNow;
            obj.CreatedBy = new Guid("a7a18502-bc39-41a2-41f6-08db607bb31e");
            context.tblItemMaster.Add(obj);
            await context.SaveChangesAsync();

            return new JsonResponse() { IsSuccess = true, Data = obj, Message = "Record saved successfully.", StatusCode = 200 };
        }

        /// <summary>
        /// Updates an existing item.
        /// </summary>
        /// <param name="obj">The item object with updated values.</param>
        /// <returns>A <see cref="JsonResponse"/> indicating the success or failure of the update operation.</returns>
        public async Task<JsonResponse> Update(ItemMaster obj)
        {
            var record = await context.tblItemMaster.Where(x => x.Id == obj.Id && x.IsActive == true).FirstOrDefaultAsync();
            if (record == null)
            {
                return new JsonResponse() { IsSuccess = false, Message = "Record not found.", StatusCode = 404 };
            }
            obj.ModifiedDate = DateTime.UtcNow;
            obj.ModifiedBy = new Guid("a7a18502-bc39-41a2-41f6-08db607bb31e");
            context.tblItemMaster.Update(obj);
            await context.SaveChangesAsync();

            return new JsonResponse() { IsSuccess = true, Message = "Record updated successfully.", StatusCode = 200 };
        }
    }
}
