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
    public class OrderMasterQueryRepository : IOrderMasterQueryRepository
    {
        private readonly EFCoreDbContext context;

        public OrderMasterQueryRepository(EFCoreDbContext _context)
        {
            context = _context;
        }

        // Retrieves all order master records
        public async Task<JsonResponse> GetAll()
        {
            var list = await context.tblOrderMaster.Where(x => x.IsActive == true).ToListAsync();
            return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = list };
        }

        // Retrieves order master records by store ID
        public async Task<JsonResponse> GetByStoreId(Guid id)
        {
            var obj = await context.tblOrderMaster.Where(x => x.StoreId == id && x.IsActive == true).ToListAsync();
            if (obj == null)
            {
                return new JsonResponse() { IsSuccess = false, StatusCode = 404, Message = "Record Not Found." };
            }
            return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = obj };
        }

        // Retrieves order master records by customer ID
        public async Task<JsonResponse> GetByCustomerId(Guid id)
        {
            var obj = await context.tblOrderMaster.Where(x => x.CustomerId == id && x.IsActive == true).ToListAsync();
            if (obj == null)
            {
                return new JsonResponse() { IsSuccess = false, StatusCode = 404, Message = "Record Not Found." };
            }
            return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = obj };
        }

        // Retrieves an order master record by ID
        public async Task<JsonResponse> GetById(Guid id)
        {
            var obj = await context.tblOrderMaster.Where(x => x.Id == id && x.IsActive == true).FirstOrDefaultAsync();
            if (obj == null)
            {
                return new JsonResponse() { IsSuccess = false, StatusCode = 404, Message = "Record Not Found." };
            }

            return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = obj };
        }

    }
}
