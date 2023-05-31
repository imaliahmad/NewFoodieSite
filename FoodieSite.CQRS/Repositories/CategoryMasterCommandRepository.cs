using FoodieSite.CQRS.Data;
using FoodieSite.CQRS.Models;
using FoodieSite.CQRS.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Repositories
{
    /// <summary>
    /// Repository for performing insert, update and delete operations on CategoryMaster entities.
    /// </summary>
    public class CategoryMasterCommandRepository : ICategoryMasterCommandRepository
    {
        private readonly EFCoreDbContext context;

        public CategoryMasterCommandRepository(EFCoreDbContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// Deletes a category by ID.
        /// </summary>
        /// <param name="id">The ID of the category to delete.</param>
        /// <returns>A <see cref="JsonResponse"/> indicating the result of the delete operation.</returns>
        public async Task<JsonResponse> Delete(Guid id)
        {
            var obj = await context.tblCategoryMaster.Where(x => x.Id == id && x.IsActive == true).FirstOrDefaultAsync();
            if (obj == null)
            {
                return new JsonResponse() { IsSuccess = false, Message = "Record not found.", StatusCode = 404 };
            }

            // Soft delete by setting IsActive flag to false
            obj.IsActive = false;
            context.tblCategoryMaster.Update(obj);
            await context.SaveChangesAsync();

            return new JsonResponse() { IsSuccess = true, Message = "Record deleted successfully.", StatusCode = 200 };
        }

        /// <summary>
        /// Inserts a new category.
        /// </summary>
        /// <param name="obj">The <see cref="CategoryMaster"/> object representing the category to insert.</param>
        /// <returns>A <see cref="JsonResponse"/> indicating the result of the insert operation.</returns>
        public async Task<JsonResponse> Insert(CategoryMaster obj)
        {
            obj.IsActive = true;
            obj.CreatedDate = DateTime.UtcNow;
            obj.CreatedBy = new Guid("a7a18502-bc39-41a2-41f6-08db607bb31e");
            context.tblCategoryMaster.Add(obj);
            await context.SaveChangesAsync();

            return new JsonResponse() { IsSuccess = true, Data = obj, Message = "Record saved successfully.", StatusCode = 200 };
        }

        /// <summary>
        /// Updates an existing category.
        /// </summary>
        /// <param name="obj">The <see cref="CategoryMaster"/> object representing the category to update.</param>
        /// <returns>A <see cref="JsonResponse"/> indicating the result of the update operation.</returns>
        public async Task<JsonResponse> Update(CategoryMaster obj)
        {
            var record = await context.tblCategoryMaster.Where(x => x.Id == obj.Id && x.IsActive == true).FirstOrDefaultAsync();
            if (record == null)
            {
                return new JsonResponse() { IsSuccess = false, Message = "Record not found.", StatusCode = 404 };
            }

            obj.ModifiedDate = DateTime.UtcNow;
            obj.ModifiedBy = new Guid("a7a18502-bc39-41a2-41f6-08db607bb31e");
            context.tblCategoryMaster.Update(obj);
            await context.SaveChangesAsync();

            return new JsonResponse() { IsSuccess = true, Message = "Record updated successfully.", StatusCode = 200 };
        }
    }
}
