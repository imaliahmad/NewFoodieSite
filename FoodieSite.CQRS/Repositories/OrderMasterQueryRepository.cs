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
    /// Repository for querying order master records.
    /// </summary>
    public class OrderMasterQueryRepository : IOrderMasterQueryRepository
    {
        private readonly EFCoreDbContext context;

        public OrderMasterQueryRepository(EFCoreDbContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// Retrieves all order master records.
        /// </summary>
        /// <returns>A <see cref="JsonResponse"/> containing the retrieved order master records.</returns>
        public async Task<JsonResponse> GetAll()
        {
            var list = await context.tblOrderMaster.Where(x => x.IsActive == true).ToListAsync();
            return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = list };
        }

        /// <summary>
        /// Retrieves order master records by store ID.
        /// </summary>
        /// <param name="id">The ID of the store.</param>
        /// <returns>A <see cref="JsonResponse"/> containing the retrieved order master records.</returns>
        public async Task<JsonResponse> GetByStoreId(Guid id)
        {
            var obj = await context.tblOrderMaster.Where(x => x.StoreId == id && x.IsActive == true).ToListAsync();
            if (obj == null)
            {
                return new JsonResponse() { IsSuccess = false, StatusCode = 404, Message = "Record Not Found." };
            }
            return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = obj };
        }

        /// <summary>
        /// Retrieves order master records by customer ID.
        /// </summary>
        /// <param name="id">The ID of the customer.</param>
        /// <returns>A <see cref="JsonResponse"/> containing the retrieved order master records.</returns>
        public async Task<JsonResponse> GetByCustomerId(Guid id)
        {
            var obj = await context.tblOrderMaster.Where(x => x.CustomerId == id && x.IsActive == true).ToListAsync();
            if (obj == null)
            {
                return new JsonResponse() { IsSuccess = false, StatusCode = 404, Message = "Record Not Found." };
            }
            return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = obj };
        }

        /// <summary>
        /// Retrieves an order master record by ID.
        /// </summary>
        /// <param name="id">The ID of the order master record.</param>
        /// <returns>A <see cref="JsonResponse"/> containing the retrieved order master record.</returns>
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
