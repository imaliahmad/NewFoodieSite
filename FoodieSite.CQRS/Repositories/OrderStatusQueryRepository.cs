﻿using FoodieSite.CQRS.Data;
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
    /// Repository for querying order status records.
    /// </summary>
    public class OrderStatusQueryRepository : IOrderStatusQueryRepository
    {
        private readonly EFCoreDbContext context;

        public OrderStatusQueryRepository(EFCoreDbContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// Retrieves all order status records.
        /// </summary>
        /// <returns>A <see cref="JsonResponse"/> containing the list of order status records.</returns>
        public async Task<JsonResponse> GetAll()
        {
            var list = await context.tblOrderStatus.Where(x => x.IsActive == true).ToListAsync();
            return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = list };
        }

        /// <summary>
        /// Retrieves order status records by order ID.
        /// </summary>
        /// <param name="id">The ID of the order.</param>
        /// <returns>A <see cref="JsonResponse"/> containing the list of order status records.</returns>
        public async Task<JsonResponse> GetByOrderId(Guid id)
        {
            var obj = await context.tblOrderStatus.Where(x => x.OrderId == id && x.IsActive == true).ToListAsync();
            if (obj == null)
            {
                return new JsonResponse() { IsSuccess = false, StatusCode = 404, Message = "Record Not Found." };
            }
            return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = obj };
        }

        /// <summary>
        /// Retrieves an order status record by ID.
        /// </summary>
        /// <param name="id">The ID of the order status record.</param>
        /// <returns>A <see cref="JsonResponse"/> containing the order status record.</returns>
        public async Task<JsonResponse> GetById(Guid id)
        {
            var obj = await context.tblOrderStatus.Where(x => x.Id == id && x.IsActive == true).FirstOrDefaultAsync();
            if (obj == null)
            {
                return new JsonResponse() { IsSuccess = false, StatusCode = 404, Message = "Record Not Found." };
            }

            return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = obj };
        }
    }
}
