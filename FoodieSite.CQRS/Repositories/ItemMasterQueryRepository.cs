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
    /// Repository for retrieving data related to ItemMaster entities.
    /// </summary>
    public class ItemMasterQueryRepository : IItemMasterQueryRepository
    {
        private readonly EFCoreDbContext context;

        public ItemMasterQueryRepository(EFCoreDbContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// Retrieves all items.
        /// </summary>
        /// <returns>A <see cref="JsonResponse"/> containing the list of items.</returns>
        public async Task<JsonResponse> GetAll()
        {
            var list = await context.tblItemMaster.Where(x => x.IsActive == true).ToListAsync();
            return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = list };
        }

        /// <summary>
        /// Retrieves items by category ID.
        /// </summary>
        /// <param name="id">The ID of the category.</param>
        /// <returns>A <see cref="JsonResponse"/> containing the list of items for the specified category.</returns>
        public async Task<JsonResponse> GetByCategoryId(Guid id)
        {
            var obj = await context.tblItemMaster.Where(x => x.CategoryId == id && x.IsActive == true).ToListAsync();
            if (obj == null)
            {
                return new JsonResponse() { IsSuccess = false, StatusCode = 404, Message = "Record Not Found." };
            }

            return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = obj };
        }

        /// <summary>
        /// Retrieves an item by ID.
        /// </summary>
        /// <param name="id">The ID of the item.</param>
        /// <returns>A <see cref="JsonResponse"/> containing the item details.</returns>
        public async Task<JsonResponse> GetById(Guid id)
        {
            var obj = await context.tblItemMaster.Where(x => x.Id == id && x.IsActive == true).FirstOrDefaultAsync();
            if (obj == null)
            {
                return new JsonResponse() { IsSuccess = false, StatusCode = 404, Message = "Record Not Found." };
            }

            return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = obj };
        }
    }
}
