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
    public class StoreMasterQueryRepository : IStoreMasterQueryRepository
    {
        private readonly EFCoreDbContext context;

        public StoreMasterQueryRepository(EFCoreDbContext _context)
        {
            context = _context;
        }

        // Retrieves all store master records
        public async Task<JsonResponse> GetAll()
        {
            var list = await context.tblStoreMaster.Where(x => x.IsActive == true).ToListAsync();
            return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = list };
        }

        // Retrieves store master records by restaurant ID
        public async Task<JsonResponse> GetByRestaurantId(Guid id)
        {
            var obj = await context.tblStoreMaster.Where(x => x.RestaurantId == id && x.IsActive == true).ToListAsync();
            if (obj == null)
            {
                return new JsonResponse() { IsSuccess = false, StatusCode = 404, Message = "Record Not Found." };
            }

            return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = obj };
        }

        // Retrieves a store master record by ID
        public async Task<JsonResponse> GetById(Guid id)
        {
            var obj = await context.tblStoreMaster.Where(x => x.Id == id && x.IsActive == true).FirstOrDefaultAsync();
            if (obj == null)
            {
                return new JsonResponse() { IsSuccess = false, StatusCode = 404, Message = "Record Not Found." };
            }

            return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = obj };
        }
    }
}
