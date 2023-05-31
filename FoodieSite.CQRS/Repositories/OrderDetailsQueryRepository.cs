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
    /// Repository for retrieving order detail records.
    /// </summary>
    public class OrderDetailsQueryRepository : IOrderDetailsQueryRepository
    {
        private readonly EFCoreDbContext context;

        public OrderDetailsQueryRepository(EFCoreDbContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// Retrieves all order detail records.
        /// </summary>
        /// <returns>A <see cref="JsonResponse"/> containing the list of order detail records.</returns>
        public async Task<JsonResponse> GetAll()
        {
            var list = await context.tblOrderDetails.Where(x => x.IsActive == true).ToListAsync();
            return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = list };
        }

        /// <summary>
        /// Retrieves order detail records by order ID.
        /// </summary>
        /// <param name="id">The ID of the order to retrieve the order detail records for.</param>
        /// <returns>A <see cref="JsonResponse"/> containing the list of order detail records.</returns>
        public async Task<JsonResponse> GetByOrderId(Guid id)
        {
            var obj = await context.tblOrderDetails.Where(x => x.OrderId == id && x.IsActive == true).ToListAsync();
            if (obj == null)
            {
                return new JsonResponse() { IsSuccess = false, StatusCode = 404, Message = "Record Not Found." };
            }
            return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = obj };
        }

        /// <summary>
        /// Retrieves an order detail record by ID.
        /// </summary>
        /// <param name="id">The ID of the order detail record to retrieve.</param>
        /// <returns>A <see cref="JsonResponse"/> containing the order detail record.</returns>
        public async Task<JsonResponse> GetById(Guid id)
        {
            var obj = await context.tblOrderDetails.Where(x => x.Id == id && x.IsActive == true).FirstOrDefaultAsync();
            if (obj == null)
            {
                return new JsonResponse() { IsSuccess = false, StatusCode = 404, Message = "Record Not Found." };
            }

            return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = obj };
        }
    }
}
