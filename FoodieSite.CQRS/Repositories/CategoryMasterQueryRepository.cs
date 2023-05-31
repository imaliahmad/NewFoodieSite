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
    /// Repository for retrieving data related to CategoryMaster entities.
    /// </summary>
    public class CategoryMasterQueryRepository : ICategoryMasterQueryRepository
    {
        private readonly EFCoreDbContext context;

        public CategoryMasterQueryRepository(EFCoreDbContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// Retrieves all categories.
        /// </summary>
        /// <returns>A <see cref="JsonResponse"/> containing the list of categories.</returns>
        public async Task<JsonResponse> GetAll()
        {
            var list = await context.tblCategoryMaster.Where(x => x.IsActive == true).ToListAsync();
            return new JsonResponse { IsSuccess = true, StatusCode = 200, Data = list };
        }

        /// <summary>
        /// Retrieves categories by StoreId.
        /// </summary>
        /// <param name="id">The StoreId to filter the categories.</param>
        /// <returns>A <see cref="JsonResponse"/> containing the list of categories filtered by StoreId.</returns>
        public async Task<JsonResponse> GetByStoreId(Guid id)
        {
            var obj = await context.tblCategoryMaster.Where(x => x.StoreId == id && x.IsActive == true).ToListAsync();
            if (obj == null)
            {
                return new JsonResponse { IsSuccess = false, StatusCode = 404, Message = "Record Not Found." };
            }

            return new JsonResponse { IsSuccess = true, StatusCode = 200, Data = obj };
        }

        /// <summary>
        /// Retrieves a category by Id.
        /// </summary>
        /// <param name="id">The Id of the category to retrieve.</param>
        /// <returns>A <see cref="JsonResponse"/> containing the category with the specified Id.</returns>
        public async Task<JsonResponse> GetById(Guid id)
        {
            var obj = await context.tblCategoryMaster.Where(x => x.Id == id && x.IsActive == true).FirstOrDefaultAsync();
            if (obj == null)
            {
                return new JsonResponse { IsSuccess = false, StatusCode = 404, Message = "Record Not Found." };
            }

            return new JsonResponse { IsSuccess = true, StatusCode = 200, Data = obj };
        }
    }
}
