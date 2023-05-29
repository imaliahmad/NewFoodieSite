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
    public class CategoryMasterQueryRepository : ICategoryMasterQueryRepository
    {
        private readonly EFCoreDbContext context;

        public CategoryMasterQueryRepository(EFCoreDbContext _context)
        {
            context = _context;
        }

        // Retrieves all categories
        public async Task<JsonResponse> GetAll()
        {
            var list = await context.tblCategoryMaster.Where(x => x.IsActive == true).ToListAsync();
            return new JsonResponse { IsSuccess = true, StatusCode = 200, Data = list };
        }

        // Retrieves categories by StoreId
        public async Task<JsonResponse> GetByStoreId(Guid id)
        {
            var obj = await context.tblCategoryMaster.Where(x => x.StoreId == id && x.IsActive == true).ToListAsync();
            if (obj == null)
            {
                return new JsonResponse { IsSuccess = false, StatusCode = 404, Message = "Record Not Found." };
            }

            return new JsonResponse { IsSuccess = true, StatusCode = 200, Data = obj };
        }

        // Retrieves a category by Id
        public async Task<JsonResponse> GetById(Guid id)
        {
            var obj = await context.tblCategoryMaster.Where(x => x.Id == id && x.IsActive==true).FirstOrDefaultAsync();
            if (obj == null)
            {
                return new JsonResponse { IsSuccess = false, StatusCode = 404, Message = "Record Not Found." };
            }

            return new JsonResponse { IsSuccess = true, StatusCode = 200, Data = obj };
        }
    }
}
