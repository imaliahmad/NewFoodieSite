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
    /// Repository for retrieving store master records.
    /// </summary>
    public class StoreMasterQueryRepository : IStoreMasterQueryRepository
    {
        private readonly EFCoreDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreMasterQueryRepository"/> class.
        /// </summary>
        /// <param name="_context">The EF Core database context.</param>
        public StoreMasterQueryRepository(EFCoreDbContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// Retrieves all store master records.
        /// </summary>
        /// <returns>A <see cref="JsonResponse"/> containing the retrieved store master records.</returns>
        public async Task<JsonResponse> GetAll()
        {
            var list = await context.tblStoreMaster.Where(x => x.IsActive == true).ToListAsync();
            return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = list };
        }

        /// <summary>
        /// Retrieves store master records by restaurant ID.
        /// </summary>
        /// <param name="id">The ID of the restaurant.</param>
        /// <returns>A <see cref="JsonResponse"/> containing the retrieved store master records.</returns>
        public async Task<JsonResponse> GetByRestaurantId(Guid id)
        {
            var obj = await context.tblStoreMaster.Where(x => x.RestaurantId == id && x.IsActive == true).ToListAsync();
            if (obj == null)
            {
                return new JsonResponse() { IsSuccess = false, StatusCode = 404, Message = "Record Not Found." };
            }

            return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = obj };
        }

        /// <summary>
        /// Retrieves a store master record by ID.
        /// </summary>
        /// <param name="id">The ID of the store master record.</param>
        /// <returns>A <see cref="JsonResponse"/> containing the retrieved store master record.</returns>
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
